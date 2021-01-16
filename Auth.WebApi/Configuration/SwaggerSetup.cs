using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.WebApi.Configuration
{
   /// <summary>
   ///   Add swagger setup.
   /// </summary>
   public static class SwaggerSetup
   {
      /// <summary>
      ///   Add swagger configuration to service collection.
      /// </summary>
      /// <param name="services"></param>
      public static void AddSwagger(this IServiceCollection services)
      {
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
               Version = "V1",
               Title = "Authentication API",
               Description = "A user authentication API.",
               Contact = new Microsoft.OpenApi.Models.OpenApiContact
               {
                  Name = "Nathan Marsh",
                  Email = string.Empty,
                  Url = new Uri("https://twitter.com/itsdarkcloudtv")
               }
            });
         });
      }
   }
}
