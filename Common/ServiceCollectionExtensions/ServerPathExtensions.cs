using Common.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ServiceCollectionExtensions
{
    /// <summary>
    /// Service Extension Library for Common services
    /// </summary>
    public static class ServerPathExtensions
    {
        public static IServiceCollection AddPathService(this IServiceCollection services)
        {
            return services.AddScoped<PathService>();
        }
    }
}
