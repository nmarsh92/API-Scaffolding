using Auth.Infrastructure.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.WebApi.Configuration
{
   /// <summary>
   ///   Setup custom attributes.
   /// </summary>
   public static class AttributeSetup
   {
      public static void AddAttributes(this IServiceCollection services)
      {
         services.AddScoped<TransactionAttributeFilter>();
      }
   }
}
