using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;
using System.IO;
using System.Reflection;

using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace KickStarter.ServiceLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();

            try
            {
                logger.Debug("init main");

                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseSetting("detailedErrors", "true")
                    .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.SetMinimumLevel(LogLevel.Trace);
                    })
                    .UseNLog()
                    .CaptureStartupErrors(true)
                    .UseApplicationInsights()
                    .Build();

                host.Run();
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                logger.Error(ex, Assembly.GetEntryAssembly().GetName().Name);
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                LogManager.Shutdown();
            }
        }
    }
}
