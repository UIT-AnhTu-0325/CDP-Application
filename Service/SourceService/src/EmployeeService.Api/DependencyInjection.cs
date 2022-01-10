using SourceService.Api.Helper;
using SourceService.Core.Interfaces.Repositories;
using SourceService.Core.Interfaces.Services;
using SourceService.Core.Services;
using SourceService.Infrastructure.Context;
using SourceService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace SourceService.Api
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
            dbConnectionString = configuration.GetConnectionString("Source");

            services.AddCors();

            services.AddDbContext<SourceDbContext>(
                optionsAction: options => options.UseSqlServer(dbConnectionString),
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<ISourceService, SourceService.Core.Services.SourceService>();
            services.AddScoped<ISourceRepository, SourceRepository>();
            services.AddScoped<JwtService>();
            services.AddHttpClient();
            return services;
        }
    }
}
