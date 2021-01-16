using NHibernate;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Domain.Repositories
{
   ///<inheritdoc/>
   public abstract class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId>
   {
      [NotNull]
      protected ISession Session { get; }

      public RepositoryBase([NotNull] ISession session)
      {
         Session = session ?? throw new ArgumentNullException(nameof(session));
      }

      ///<inheritdoc/>
      public Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken = default)
         => Session.GetAsync<TEntity>(id, cancellationToken);

      ///<inheritdoc/>
      public async Task<TEntity> SaveAsync(TEntity entity, CancellationToken cancellationToken = default)
      {
         await Session.SaveAsync(entity, cancellationToken);
         await Session.FlushAsync();
         return entity; 
      }

      ///<inheritdoc/>
      public async Task<TEntity> SaveOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
      {
         await Session.SaveOrUpdateAsync(entity, cancellationToken);
         return entity;
      }

      ///<inheritdoc/>
      public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default) => Session.DeleteAsync(entity, cancellationToken);

      ///<inheritdoc/>
      public async Task DeleteAsync(TId id, CancellationToken cancellationToken = default)
      {
         var entity = await GetAsync(id, cancellationToken).ConfigureAwait(false);
         if (entity != null) await DeleteAsync(entity, cancellationToken);
      }

   }
}
