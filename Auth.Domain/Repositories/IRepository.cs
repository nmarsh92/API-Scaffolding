using NHibernate;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Domain.Repositories
{
   /// <summary>
   ///   Default NHibernate repository with methods using the NHibernate session.
   /// </summary>
   public interface IRepository<TEntity, in TId>
   {
      /// <summary>
      ///   Load a persistent entity.
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      Task<TEntity> GetAsync(TId id, CancellationToken cancellationToken = default(CancellationToken));

      /// <summary>
      ///   Persist a transient object. Will create an ID if generator is mapped.
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      Task<TEntity> SaveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

      /// <summary>
      ///   Save or update given entity depending on the id.
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      Task<TEntity> SaveOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

      /// <summary>
      ///   Remove persistent entity from datastore using provided id.
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      Task DeleteAsync(TId id, CancellationToken cancellationToken = default(CancellationToken));

      /// <summary>
      ///   Remove persistent entity from datastore.
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
   }
}
