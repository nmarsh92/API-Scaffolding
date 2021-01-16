using Auth.Api.Models.User;
using Auth.Domain.Repositories;
using Auth.Domain.Services;
using Auth.Infrastructure.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.WebApi.Controllers
{
   [Route("api/v1/[controller]")]
   [ApiController]
   [ServiceFilter(typeof(TransactionAttributeFilter))]
   public class UserController : Controller
   {
      private readonly IUserRepository _userRepository;
      private readonly IUserService _userService;
      private readonly ILogger _logger;
      public UserController(ILogger<UserController> logger, IUserRepository userRepository, IUserService userService)
      {
         _logger = logger ?? throw new ArgumentNullException(nameof(logger));
         _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
         _userService = userService ?? throw new ArgumentNullException(nameof(userService));
      }

      [HttpGet]
      [Route("{userId}", Name ="GetUser")]
      public async Task<ActionResult<User>> Get([FromRoute] Guid userId, CancellationToken cancellationToken)
      {
         _logger.LogInformation("Request to GET user {userId}", userId);
         var user = await _userService.GetUserAsync(userId, cancellationToken).ConfigureAwait(false);

         if (user != null)
         {
            return Ok(user);
         }

         return NotFound();
      }

      [HttpPatch]
      [Route("{userId}", Name = "UpdateEmail")]
      public async Task<ActionResult> UpdateEmail([FromRoute] Guid userId, [FromBody] UpdateEmailRequest updateEmailRequest, CancellationToken cancellationToken)
      {
         await _userService.UpdateUserEmailAsync(userId, updateEmailRequest.Email, cancellationToken).ConfigureAwait(false);
        
         _logger.LogInformation("Successfully updated email for {userId}", userId);
         return Ok();
      }

      [HttpPost]
      [Route("", Name = "CreateUser")]
      public async Task<ActionResult<User>> Create([FromBody] CreateUserRequest createUserRequest, CancellationToken cancellationToken)
      {
         var user = await _userService.CreateUserAsync(createUserRequest, cancellationToken).ConfigureAwait(false);

         _logger.LogInformation("Successfully created user {id}", user.Id);
         return Ok(user);
      }

      [HttpDelete]
      [Route("{userId}", Name = "DeleteUser")]
      public async Task<ActionResult<User>> Delete([FromRoute] Guid userId, CancellationToken cancellationToken)
      {
         _logger.LogInformation("Request to DELETE user {userId}", userId);
          await _userService.DeleteUserAsync(userId, cancellationToken).ConfigureAwait(false);
         return Ok();
      }
   }
}
