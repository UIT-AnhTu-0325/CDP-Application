using AutoMapper;

namespace AuthenticationService.Api.Helper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Infrastructure.Entities.Employee, Core.Models.Employee>().ReverseMap();
            CreateMap<Infrastructure.Entities.User, Core.Models.User>().ReverseMap();

        }
    }
}
