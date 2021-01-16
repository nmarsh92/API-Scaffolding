using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Auth.Api.Models.User
{
   /// <summary>
   ///   User class.
   /// </summary>
   [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
   public class User : ApiModelBase
   {
      /// <summary>
      ///   Email.
      /// </summary>
      public string Email { get; set; }

   }
}
