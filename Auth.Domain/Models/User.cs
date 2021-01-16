using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Models
{
   /// <summary>
   ///   User entity.
   /// </summary>
   public class User : DomainModelBase
   {
      /// <summary>
      ///   User email.
      /// </summary>
      public virtual string Email { get; set; }
   }
}
