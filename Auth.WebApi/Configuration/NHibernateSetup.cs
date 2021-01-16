using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Auth.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Auth.Infrastructure.Conventions;
using Auth.Infrastructure.Interceptors;
using Auth.Infrastructure.Mapping;

namespace Auth.WebApi.Configuration
{
   /// <summary>
   ///   Setup Nhibernate.
   /// </summary>
   public static class NHibernateSetup
   {
      /// <summary>
      ///   Add NHibernate configuration.
      /// </summary>
      /// <param name="services"></param>
      /// <param name="connectionString"></param>
      public static void AddNHibernate(this IServiceCollection services, string connectionString)
      {
         var sessionFactory = Fluently.Configure()
                              .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
                              .Mappings(m => m.AutoMappings
                                       .Add(AutoMap.AssemblyOf<User>()
                                          .Where(x => x.Namespace.Contains("Models"))
                                          .Conventions
                                          .Add(new UtcConvention(), new AuditConvention())
                                          .IgnoreBase<DomainModelBase>()
                                          .UseOverridesFromAssemblyOf<UserMap>
                                          )
                                       )
                              .BuildSessionFactory();
         services.AddScoped(factory =>
         {
            return sessionFactory.WithOptions().Interceptor(new LoggingInterceptor()).OpenSession();
         });

      }
   }
}
