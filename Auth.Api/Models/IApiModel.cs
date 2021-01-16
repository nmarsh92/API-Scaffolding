using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Api.Models
{
   /// <summary>
   ///   Base model for api.
   /// </summary>
   public interface IApiModel
   {
      /// <summary>
      ///   Id.
      /// </summary>
      Guid Id { get; set; }

      /// <summary>
      ///   Creation date.
      /// </summary>
      DateTime CreatedAtUtc { get; set; }

      /// <summary>
      ///   Updated date.
      /// </summary>
      DateTime UpdatedAtUtc { get; set; }
   }
}
