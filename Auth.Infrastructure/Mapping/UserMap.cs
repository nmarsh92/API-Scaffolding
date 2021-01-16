using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Auth.Domain.Models;
using System;

namespace Auth.Infrastructure.Mapping
{
   /// <inheritdoc/>
   public class UserMap : IAutoMappingOverride<User>
   {
      public void Override(AutoMapping<User> mapping)
      {
         mapping.Schema("Auth");
         mapping.Table("User");
         mapping.Id(x => x.Id, "id")
            .GeneratedBy
            .GuidComb()
            .UnsavedValue(Guid.Empty);
         mapping.Map(x => x.Email)
            .Unique();
      }
   }
}
