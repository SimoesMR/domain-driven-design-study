using Domain.Repositories;
using Domain.Repositories.User;
using FluentMigrator.Runner;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
            AddFluentMigratior(services, configuration);
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            var serverVersion = new MySqlServerVersion(new Version(8,0,35));

            //usando mysql
            services.AddDbContext<ApiDbContext>(dbContextOptions =>
            {
                dbContextOptions.UseMySql(connectionString, serverVersion);
            });

        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        }

        private static void AddFluentMigratior(IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentMigratorCore().ConfigureRunner(option =>
            {
                option
                .AddMySql8()
                .WithGlobalConnectionString(configuration.GetConnectionString("Connection"))
                .ScanIn(Assembly.Load("Infrastructure")).For.All();
            });
        }
    }
}
