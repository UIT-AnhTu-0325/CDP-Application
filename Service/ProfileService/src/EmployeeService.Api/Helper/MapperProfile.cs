using AutoMapper;

namespace ProfileService.Api.Helper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Infrastructure.Entities.Profile, Core.Models.Profile>().ReverseMap();

        }
    }
}
