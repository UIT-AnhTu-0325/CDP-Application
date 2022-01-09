using ProfileService.Api.Helper;
using ProfileService.Core.Interfaces.Repositories;
using ProfileService.Core.Interfaces.Services;
using ProfileService.Core.Services;
using ProfileService.Infrastructure.Context;
using ProfileService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ProfileService.Api
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
            dbConnectionString = configuration.GetConnectionString("Profile");

            services.AddCors();

            services.AddDbContext<ProfileDbContext>(
                optionsAction: options => options.UseSqlServer(dbConnectionString),
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<IProfileService, ProfileService.Core.Services.ProfileService>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<JwtService>();
            services.AddHttpClient();
            return services;
        }
    }
}
