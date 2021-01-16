using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Conventions
{
   /// <summary>
   ///   Convention to handle audit properties.
   /// </summary>
   public class AuditConvention : IPropertyConvention
   {
      /// <inheritdoc/>
      public void Apply(IPropertyInstance instance)
      {
         if (instance.Property.Name.ToLower() == "createdatutc" || instance.Property.Name.ToLower() == "updatedatutc")
         {
            instance.CustomType<UtcDateTimeType>();
            instance.Generated.Always();
         }
      }
   }
}
