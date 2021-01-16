using AutoMapper;

namespace Auth.Domain.Profiles
{
   public class UserProfile : Profile
   {
      public UserProfile()
      {
         CreateMap<Models.User, Api.Models.User.User>();
         CreateMap<Api.Models.User.User, Models.User>();
         CreateMap<Api.Models.User.CreateUserRequest, Models.User>()
            .ForMember(x => x.Id, opt => opt.Ignore())
            .ForMember(x => x.UpdatedAtUtc, opt => opt.Ignore())
            .ForMember(x => x.CreatedAtUtc, opt => opt.Ignore());
      }
   }
}
