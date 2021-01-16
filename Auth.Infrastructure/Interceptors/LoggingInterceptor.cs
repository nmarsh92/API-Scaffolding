using Microsoft.Extensions.Logging;
using NHibernate;
using NHibernate.SqlCommand;
using System.Collections.Generic;

namespace Auth.Infrastructure.Interceptors
{
   public class LoggingInterceptor : EmptyInterceptor
   {
      private readonly ILogger _logger;
      public LoggingInterceptor()
      {
         var logFactory = LoggerFactory.Create(x => x.AddConsole());
         _logger = logFactory.CreateLogger<LoggingInterceptor>();
      }
      public override SqlString OnPrepareStatement(SqlString sql)
      {
         _logger.LogInformation(sql.ToString());
         
         return sql;
      }

   }
}
