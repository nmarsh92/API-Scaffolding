using System;

namespace Auth.Api.Models
{
   ///<inheritdoc/>
   public class ApiModelBase : IApiModel
   {
      ///<inheritdoc/>
      public Guid Id { get; set; }

      ///<inheritdoc/>
      public DateTime CreatedAtUtc { get; set; }

      ///<inheritdoc/>
      public DateTime UpdatedAtUtc { get; set; }
   }
}
