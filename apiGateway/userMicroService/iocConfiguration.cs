using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using userMicroService.Data.Contract.Repository;
using userMicroService.Data.Contract.Services;
using userMicroService.Data.Dto.Outcomming;
using userMicroService.Data.Managers;
using userMicroService.Data.Repository;
using userMicroService.Data.Services;

namespace userMicroService.IoCApplication
{
    public static class IocConfiguration
    {

        public static IServiceCollection ConfigureInjectionDependencyRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }


        public static IServiceCollection ConfigureInjectionDependencyService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserManager, UserManager>();

            services.AddSingleton<IConfiguration>(configuration);

            services.AddScoped<MapperConfiguration>(cfg => new MapperConfiguration(cfg => cfg.AddProfile<UserMapper>()));
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<MapperConfiguration>(), sp.GetService));

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

    public static class IocConfigurationTest
    {
        public static IServiceCollection ConfigureInjectionDependencyRepositoryTest(this IServiceCollection services)
        {
            services.ConfigureInjectionDependencyRepository();

            return services;

        }

        public static IServiceCollection ConfigureInjectionDependencyServiceTest(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureInjectionDependencyService(configuration);

            return services;
        }

        public static IServiceCollection ConfigureDBContextTest(this IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                );

            return services;
        }

    }
}
