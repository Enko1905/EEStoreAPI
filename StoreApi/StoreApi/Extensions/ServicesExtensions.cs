using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EfCore;
using Services;
using Services.Contracts;

namespace StoreApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureMysqlContext(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<RepositoryContext>(option =>
                option.UseMySQL(configuration.GetConnectionString("MysqlConnection"))
            );
        }
        public static void ConfigureSqlContext(this IServiceCollection service, IConfiguration configuration)
        {
           service.AddDbContext<RepositoryContext>(option => option.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));
        }
        public static void ConfigureRepositoryManager(this IServiceCollection service)
        {
            service.AddScoped<IRepositoryManager, RepositoryManager>();
        }
        public static void ConfigureServicesManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();

        }
    }
}
