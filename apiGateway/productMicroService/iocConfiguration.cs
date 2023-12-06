using Microsoft.EntityFrameworkCore;
using productMicroService.Data.Contract.Services;
using productMicroService.Data.Services;
using productMicroService.Data.Contract.Repository;
using productMicroService.Data.Repository;
using AutoMapper;
using productMicroService.Data.Dto.Outcomming;

namespace productMicroService.IoCApplication
{
    public static class IocConfiguration
    {

        public static IServiceCollection ConfigureInjectionDependencyRepository(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }


        public static IServiceCollection ConfigureInjectionDependencyService(this IServiceCollection services)
        {
            services.AddScoped<MapperConfiguration>(cfg => new MapperConfiguration(cfg => cfg.AddProfile<ProductMapper>()));
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<MapperConfiguration>(), sp.GetService));


            services.AddScoped<IProductService, ProductService>();
            return services;
        }

        public static IServiceCollection ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BddConnection");

            services.AddDbContext<DatabaseContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

            return services;
        }

    }
}
