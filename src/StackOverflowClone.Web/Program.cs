using Autofac;
using Autofac.Extensions.DependencyInjection;
using log4net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackOverflowClone.Infrastructure;
using StackOverflowClone.Infrastructure.Permissions;
using StackOverflowClone.Infrastructure.Securities.Permissions;
using StackOverflowClone.Web;
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

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddIdentity();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication()
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Login");
        options.LogoutPath = new PathString("/Account/Logout");
        options.Cookie.Name = "StackOverPortal.Identity";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
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
    
});
//builder.Services.AddNHibernate(connectionString);
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddSingleton<IAuthorizationHandler, AdminManagerRequirementHandler>();



builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();

var log = LogManager.GetLogger(typeof(Program));
var app = builder.Build();

try
{

  


    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection()
        .UseStaticFiles()
        .UseRouting()
        .UseAuthentication()
        .UseAuthorization()
        .UseSession();


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

