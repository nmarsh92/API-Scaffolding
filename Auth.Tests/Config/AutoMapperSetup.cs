using Auth.Domain.Profiles;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Tests.Config
{

   public class AutoMapperSetup 
   {
      public IMapper Mapper { get; }
      public AutoMapperSetup()
      {
         var config = new MapperConfiguration(cfg =>
         {
            cfg.AddMaps(typeof(UserProfile).Assembly);
         });
         config.CompileMappings();

         Mapper = config.CreateMapper();
      }
   }
}
