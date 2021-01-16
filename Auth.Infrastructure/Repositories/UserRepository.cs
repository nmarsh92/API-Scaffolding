using Auth.Domain.Models;
using Auth.Domain.Repositories;
using Microsoft.Extensions.Logging;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Repositories
{
   ///<inheritdoc/>
   public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
   {
      private readonly ISession _session;
      private readonly ILogger _logger;

      public UserRepository(ILogger<UserRepository> logger, ISession session) : base(session)
      {
         _session = session ?? throw new ArgumentNullException(nameof(session));
         _logger = logger ?? throw new ArgumentNullException(nameof(logger));
      }
   }
}
