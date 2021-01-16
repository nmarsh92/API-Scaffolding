using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace Auth.Api
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var logFactory = LoggerFactory.Create(x => x.AddConsole());
         ILogger logger = logFactory.CreateLogger<Program>();

         try
         {
            CreateHostBuilder(args).Build().Run();
            logger.LogInformation("Application started successfully");
         }
         catch (Exception ex)
         {
            logger.LogCritical(ex, "Application experienced unrecoverable error.");
         }
         finally
         {
            logFactory.Dispose();
         }

      }

      public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args).ConfigureLogging(logging =>
          {
             logging.ClearProviders();
             logging.AddConsole();
          })
          .ConfigureWebHostDefaults(webBuilder =>
          {
             webBuilder.UseStartup<Startup>();
          });
   }
}
