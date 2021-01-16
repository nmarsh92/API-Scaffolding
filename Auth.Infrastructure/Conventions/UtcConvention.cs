using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using NHibernate.Type;

namespace Auth.Infrastructure.Conventions
{
   /// <summary>
   ///   NHibernate convetion to hydrate UTC date times from database as a UTC date time.
   /// </summary>
   public class UtcConvention : IPropertyConvention
   {
      /// <inheritdoc/>
      public void Apply(IPropertyInstance instance)
      {
         if (instance.Type.Name == "DateTime" && instance.Property.Name.ToLower().Contains("utc"))
         {
            instance.CustomType<UtcDateTimeType>();
         }
      }
   }
}
