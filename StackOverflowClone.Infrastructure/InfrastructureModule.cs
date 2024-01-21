using Autofac;
using StackOverflowClone.Infrastructure.Securities;


namespace StackOverflowClone.Infrastructure
{
    public class InfrastructureModule:Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public InfrastructureModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TokenService>().As<ITokenService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssemblyName)
                .InstancePerLifetimeScope();
            builder.RegisterType<TokenService>().As<ITokenService>()
               .InstancePerLifetimeScope();
            base.Load(builder);
        }

    }
}
