using Microsoft.Extensions.DependencyInjection;
using OperacionFuegoQuasar.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuegoQuasar.Repositories
{
    public static class DependenciesInjection
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<Context, Context>();
            services.AddScoped<ISatelliteRepository, SatelliteRepository>();
            services.AddScoped<IMessageSatelliteRepository, MessageSatelliteRepository>();
            return services;
        }
    }
}
