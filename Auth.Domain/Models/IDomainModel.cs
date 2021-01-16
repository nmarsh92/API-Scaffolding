using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Models
{
   /// <summary>
   ///   Domain model.
   /// </summary>
   interface IDomainModel
   {
      /// <summary>
      ///   Id.
      /// </summary>
      Guid Id { get; }
      /// <summary>
      ///   Creation date.
      /// </summary>
      DateTime CreatedAtUtc { get; }

      /// <summary>
      ///   Updated date.
      /// </summary>
      DateTime UpdatedAtUtc { get; }
   }
}
