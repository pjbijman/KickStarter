using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KickStarter.DataLayer.DI;

namespace Kickstarter.BusinessLayer.DI
{
    public static class ConfigureServices
    {
        public static void ConfigureBusinessLayerServices(this IServiceCollection services, IConfiguration config)
        {
            services.ConfigureDataLayerDependencies(config);
        }
    }
}