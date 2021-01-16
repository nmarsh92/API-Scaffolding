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
   ///   Create user request.
   /// </summary>
   public class CreateUserRequest
   {
      /// <summary>
      ///   Email for user to create.
      /// </summary>
      [NotNull]
      [Required]
      public string Email { get; set; }
   }
}
