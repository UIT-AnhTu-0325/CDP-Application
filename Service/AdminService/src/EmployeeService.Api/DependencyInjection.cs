using AdminService.Api.Helper;
using AdminService.Core.Interfaces.Repositories;
using AdminService.Core.Interfaces.Services;
using AdminService.Core.Services;
using AdminService.Infrastructure.Context;
using AdminService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AdminService.Api
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

            services.AddScoped<IAdminService, AdminService.Core.Services.AdminService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUserService, AdminService.Core.Services.UserService>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<JwtService>();
            services.AddHttpClient();
            return services;
        }
    }
}
