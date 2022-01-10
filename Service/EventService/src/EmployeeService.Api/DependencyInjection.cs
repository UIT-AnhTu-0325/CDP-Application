using EventService.Api.Helper;
using EventService.Core.Interfaces.Repositories;
using EventService.Core.Interfaces.Services;
using EventService.Core.Services;
using EventService.Infrastructure.Context;
using EventService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventService.Api
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
            dbConnectionString = configuration.GetConnectionString("Event");

            services.AddCors();

            services.AddDbContext<EventDbContext>(
                optionsAction: options => options.UseSqlServer(dbConnectionString),
                contextLifetime: ServiceLifetime.Transient,
                optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<IEventService, EventService.Core.Services.EventService>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<JwtService>();
            services.AddHttpClient();
            return services;
        }
    }
}
