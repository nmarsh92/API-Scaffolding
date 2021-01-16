using Auth.Api.Models.User;
using Auth.Domain.Repositories;
using Auth.Domain.Services;
using Auth.Services.Services;
using Auth.Tests.Config;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Auth.Tests
{
   public class UserServiceTests
   {
      private readonly IMapper _mapper;
      private readonly IUserService _userService;

      private readonly Mock<ILogger<UserService>> _logger;
      private readonly Mock<IUserRepository> _userRepository;

      public UserServiceTests()
      {
         _mapper = new AutoMapperSetup().Mapper;
         _userRepository = new Mock<IUserRepository>();
         _logger = new Mock<ILogger<UserService>>();

         _userService = new UserService(_logger.Object, _mapper, _userRepository.Object);
      }

      [Fact]
      public async Task Should_Return_User()
      {
         var id = Guid.NewGuid();
         var testUser = new User()
         {
            Id = id,
            Email = "test@test.com",
            CreatedAtUtc = DateTime.UtcNow,
            UpdatedAtUtc = DateTime.UtcNow
         };

         _userRepository.Setup(x => x.GetAsync(id, It.IsAny<CancellationToken>())).ReturnsAsync(_mapper.Map<Domain.Models.User>(testUser));

         var user = await _userService.GetUserAsync(id, CancellationToken.None);

         _userRepository.Verify(x => x.GetAsync(id, CancellationToken.None));

         user.Id.Should().Be(id);
      }
   }
}
