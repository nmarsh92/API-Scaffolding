using Auth.Domain.Repositories;
using Auth.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.WebApi.Configuration
{
   /// <summary>
   ///   Setup repositories.
   /// </summary>
   public static class RepositorySetup
   {
      /// <summary>
      ///   Register repositories for dependency injection.
      /// </summary>
      /// <param name="services"></param>
      public static void AddRepositories(this IServiceCollection services)
      {
         services.AddScoped<IUserRepository, UserRepository>();
      }
   }
}
