using Auth.Api.Models.User;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Domain.Services
{
   /// <summary>
   ///   Service for interacting with User.
   /// </summary>
   public interface IUserService
   {
      /// <summary>
      ///   Get user for provided id.
      /// </summary>
      /// <param name="userId">User Identifiter.</param>
      /// <param name="cancellationToken">Cancellation Token.</param>
      /// <returns></returns>
      Task<User> GetUserAsync(Guid userId, CancellationToken cancellationToken);

      /// <summary>
      ///   Update user email for provided user id.
      /// </summary>
      /// <param name="userId">User Identifiter.</param>
      /// <param name="email">New user email.</param>
      /// <param name="cancellationToken">Cancellation Token.</param>
      /// <returns></returns>
      Task UpdateUserEmailAsync(Guid userId, string email, CancellationToken cancellationToken);

      /// <summary>
      ///   Create user with provided email.
      /// </summary>
      /// <param name="createUserRequest">Create user request.</param>
      /// <param name="cancellationToken">Cancellation Token.</param>
      /// <returns></returns>
      Task<User> CreateUserAsync(CreateUserRequest createUserRequest, CancellationToken cancellationToken);

      /// <summary>
      ///   Delete user with provided id.
      /// </summary>
      /// <param name="userId">User Identifiter.</param>
      /// <param name="cancellationToken">Cancellation Token.</param>
      /// <returns></returns>
      Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken);
   }
}
