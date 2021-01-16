using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Models
{
   ///<inheritdoc/>
   public class DomainModelBase : IDomainModel
   {
      //<inheritdoc />
      public virtual Guid Id { get; }

      //<inheritdoc />
      public virtual DateTime CreatedAtUtc { get; }

      //<inheritdoc />
      public virtual DateTime UpdatedAtUtc { get; }
   }
}
