using Microsoft.Extensions.DependencyInjection;
using OperacionFuegoQuasar.Services.Implementations;
using System;

namespace OperacionFuegoQuasar.Services
{
    public static class DependenciesInjection
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services = Repositories.DependenciesInjection.ConfigureServices(services);
            services.AddScoped<ISatelliteService, SatelliteService>();
            return services;
        }
    }
}
