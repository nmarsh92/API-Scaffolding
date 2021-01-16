using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.Api.Attributes
{
   /// <summary>
   /// 
   /// </summary>
   [AttributeUsage(AttributeTargets.Method, Inherited = false)]
   public class Transaction : Attribute
   {
   }
}
