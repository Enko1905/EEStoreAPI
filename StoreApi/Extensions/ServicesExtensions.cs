using Entities.DataTransferObjects;
<<<<<<< HEAD
using Entities.Models;
=======
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
using Microsoft.EntityFrameworkCore;
using Presentation.ActionFilters;
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
        public static void ConfigureLoggerSerciesManager(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService,LoggerManager>();
        }
        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
            services.AddSingleton<LogFilterAttribute>();
            services.AddScoped<ValidateMediaTypeAttribute>();
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", builder =>
                
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("X-Pagination")
                );
            });
        }
<<<<<<< HEAD

        public static void ConfigureDataShapper(this IServiceCollection services) 
        {
            services.AddScoped<IDataShaper<ProductDto>, DataShaper<ProductDto>>();
        }
=======
        public static void ConfigureDataShapper(this IServiceCollection services)
        {
            services.AddScoped<IDataShaper<ProductDto>, DataShaper<ProductDto>>();
        }
        public static void AddCustomMediaTypes(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(config =>
            {
                var systemTextJsonOutputFormatter = config
                .OutputFormatters
                .OfType<SystemTextJsonOutputFormatter>()?.FirstOrDefault();

                if (systemTextJsonOutputFormatter != null)
                {
                    systemTextJsonOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.eestore.hateoas+json");

                   systemTextJsonOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.eestore.apiroot+json");
                }
                var xmlOutputFormatter = config
                .OutputFormatters
                .OfType<XmlDataContractSerializerOutputFormatter>()?.FirstOrDefault();

                if (xmlOutputFormatter is not null)
                {
                    xmlOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.eestore.hateoas+xml");

                    xmlOutputFormatter.SupportedMediaTypes
                    .Add("application/vnd.eestore.apiroot+xml");
                }
         
        });

        }
>>>>>>> 475fa9d2df6d15050b6f161b88f099728dd8905c
    }
}
