using Microsoft.AspNetCore.Mvc.Filters;
using NHibernate;
using System;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Filters
{
   /// <summary>
   ///   Filter to handle NHibernate transactions.
   /// </summary>
   public class TransactionAttributeFilter : ActionFilterAttribute
   {
      private readonly ISession _session;

      public TransactionAttributeFilter(ISession session)
      {
         _session = session ?? throw new ArgumentNullException(nameof(session));
      }

      /// <inheritdoc />
      public override async Task OnActionExecutionAsync(
      ActionExecutingContext context,
      ActionExecutionDelegate next)
      {
         try
         {
            _session.BeginTransaction();
            await next();
            await _session.GetCurrentTransaction().CommitAsync().ConfigureAwait(false);
         }
         catch
         {
            await _session.GetCurrentTransaction().RollbackAsync().ConfigureAwait(false);
            throw;
         }
      

      }
   }
}
