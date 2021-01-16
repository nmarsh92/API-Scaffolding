using Auth.Domain.Services;
using Auth.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.WebApi.Configuration
{
   /// <summary>
   ///   Setup repositories.
   /// </summary>
   public static class ServiceSetup
   {
      /// <summary>
      ///   Register services for dependency injection.
      /// </summary>
      /// <param name="services"></param>
      public static void AddServices(this IServiceCollection services)
      {
         services.AddScoped<IUserService, UserService>();
      }
   }
}
