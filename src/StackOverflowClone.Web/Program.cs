using Autofac;
using Autofac.Extensions.DependencyInjection;
using log4net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackOverflowClone.Infrastructure;
using StackOverflowClone.Infrastructure.Permissions;
using StackOverflowClone.Infrastructure.Securities.Permissions;
using StackOverflowClone.Web;
using StackOverflowClone.Web.Dependency;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var migrationAssembly = Assembly.GetExecutingAssembly().FullName;
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{

    containerBuilder.RegisterModule(new InfrastructureModule(connectionString, migrationAssembly));
    containerBuilder.RegisterModule(new WebModule());
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(connectionString,
  (x) => x.MigrationsAssembly(migrationAssembly)));

builder.Services.AddIdentity();
builder.Services.AddAuthentication()
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrator", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("Administrator", "Administrator");
    });
    options.AddPolicy("Manager", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("Manager", "Manager");
    });
    options.AddPolicy("AdminManager", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.Requirements.Add(new AdminManagerRequirement());
    });
    options.AddPolicy("User", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("User", "User");
    });
    options.AddPolicy("ViewRequirementPolicy", policy =>
    {
        policy.AuthenticationSchemes.Clear();
        policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();

    });
});
//builder.Services.AddNHibernate(connectionString);
builder.Services.AddSingleton<IAuthorizationHandler, AdminManagerRequirementHandler>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();

builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();

var log = LogManager.GetLogger(typeof(Program));

try
{

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();

    log.Info("Application is starting");
    app.Run();
}
catch (Exception ex)
{
    log.Fatal($"API can not start.\n{ex}");
}

