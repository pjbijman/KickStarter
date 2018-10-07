using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using KickStarter.DataLayer.EntityFramework;

namespace KickStarter.DataLayer.DI
{
    public static class ConfigureServices
    {
        public static void ConfigureDataLayerDependencies(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
            //services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll));

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(connectionString);

            var context = new DataContext(optionsBuilder.Options);
            context.Database.Migrate();
        }
    }
}