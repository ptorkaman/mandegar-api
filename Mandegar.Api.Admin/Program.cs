using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Web;
using Serilog;
using Mandegar.CoreBase.Serilog;
using System;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Mandegar.Api.Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GlobalDiagnosticsContext.Set("connectionString", GetConfiguration().GetConnectionString("NLogConnection"));
            Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {

                CreateHostBuilder(args, GetConfiguration()).Build().Run();

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }
            
            //CreateHost(args);
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) =>
           Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
              webBuilder.SuppressStatusMessages(true);
              webBuilder.UseIIS();
              webBuilder.UseIISIntegration();
              webBuilder.UseStartup<Startup>();
              webBuilder.UseUrls(configuration[$"Urls:{typeof(Program).Assembly.GetName().Name}"].Split(';'));
          })
          .ConfigureAppConfiguration(configuration =>
          {
              configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
              configuration.AddJsonFile(
                  $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                  optional: true);
          }).ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            }).UseNLog();
        //.UseSerilog(LoggingConfiguration.ConfigureLogger);

        private static void CreateHost(string[] args)
        {
            
            //try
            //{
            //    CreateHostBuilder(args, GetConfiguration()).Build().Run();
            //}
            //catch (Exception ex)
            //{
            //    Log.Fatal($"Failed to start {Assembly.GetExecutingAssembly().GetName().Name}", ex);
            //    throw;
            //}
        }

        

        private static IConfiguration GetConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                  .Build();

            return configuration;
        }
    }
}
