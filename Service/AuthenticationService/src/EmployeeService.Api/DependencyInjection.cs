using AuthenticationService.Api.Helper;
using AuthenticationService.Core.Interfaces.Repositories;
using AuthenticationService.Core.Interfaces.Services;
using AuthenticationService.Core.Services;
using AuthenticationService.Infrastructure.Context;
using AuthenticationService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            string dbConnectionString = String.Empty;
            dbConnectionString = configuration.GetConnectionString("Employee");

            services.AddCors();

            services.AddDbContext<EmployeeDbContext>(
                optionsAction: options => options.UseSqlServer(dbConnectionString),
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<IAuthenticationService, AuthenticationService.Core.Services.AuthenticationService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUserService, AuthenticationService.Core.Services.UserService>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<JwtService>();

            //Test
            services.AddScoped<MyServiceFemale>();
            services.AddScoped<MyServiceMale>();
            services.AddTransient<MySericeResolver>(serviceProvider => serviceTypeName =>
            {
                switch (serviceTypeName)
                {
                    case MyServiceType.MyServiceMale:
                        return serviceProvider.GetService<MyServiceMale>();
                    case MyServiceType.MyServiceFemale:
                        return serviceProvider.GetService<MyServiceFemale>();
                    default:
                        return null;
                }
            });

            services.AddHttpClient();
            return services;
        }
        public delegate IMyService MySericeResolver(MyServiceType myServiceType);
        public enum MyServiceType
        {
            MyServiceFemale,
            MyServiceMale
        }
    }
}
