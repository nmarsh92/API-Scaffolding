using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Api.Models.User
{
   /// <summary>
   ///   Update user email request.
   /// </summary>
   public class UpdateEmailRequest
   {
      /// <summary>
      ///   User email to update.
      /// </summary>
      [NotNull]
      [Required]
      public string Email { get; set; }
   }
}
