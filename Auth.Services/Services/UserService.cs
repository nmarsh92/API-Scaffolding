using Auth.Api.Models.User;
using Auth.Domain.Repositories;
using Auth.Domain.Services;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Services.Services
{
   /// <inheritdoc/>
   public class UserService : IUserService
   {
      private readonly IMapper _mapper;
      private readonly IUserRepository _userRepository;
      private readonly ILogger _logger;

      public UserService(ILogger<UserService> logger, IMapper mapper, IUserRepository userRepository)
      {
         _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
         _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
         _logger = logger ?? throw new ArgumentNullException(nameof(logger));
      }

      /// <inheritdoc/>
      public async Task<User> GetUserAsync(Guid userId, CancellationToken cancellationToken)
      {
         var userEntity = await _userRepository.GetAsync(userId, cancellationToken).ConfigureAwait(false);
         return _mapper.Map<User>(userEntity);
      }

      /// <inheritdoc/>
      public async Task UpdateUserEmailAsync(Guid userId, string email, CancellationToken cancellationToken)
      {
         var userEntity = await _userRepository.GetAsync(userId, cancellationToken).ConfigureAwait(false);
         userEntity.Email = email;

      }

      /// <inheritdoc/>
      public async Task<User> CreateUserAsync(CreateUserRequest createUserRequest, CancellationToken cancellationToken)
      {
         var userEntity = _mapper.Map<Domain.Models.User>(createUserRequest);
         var dbEntity = await _userRepository.SaveAsync(userEntity, cancellationToken).ConfigureAwait(false);
         return _mapper.Map<User>(dbEntity);
      }

      /// <inheritdoc/>
      public Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken) 
         => _userRepository.DeleteAsync(userId, cancellationToken);

   }
}
