using AutoMapper;

namespace EventService.Api.Helper
{
    public class MapperEvent: Profile
    {
        public MapperEvent()
        {
            CreateMap<Infrastructure.Entities.Event, Core.Models.Event>().ReverseMap();

        }
    }
}
