using Auth.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Domain.Repositories
{
   /// <summary>
   ///   Repository for performing user data actions.
   /// </summary>
   public interface IUserRepository : IRepository<User, Guid>
   {
      ///// <summary>
      /////   Get user for provided id;
      ///// </summary>
      ///// <param name="id">User id.</param>
      ///// <param name="cancellationToken">Cancellation Token.</param>
      ///// <returns></returns>
      //Task<User> Get(Guid id, CancellationToken cancellationToken);
   }
}
