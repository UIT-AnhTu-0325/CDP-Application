using AutoMapper;

namespace SourceService.Api.Helper
{
    public class MapperSource: Profile
    {
        public MapperSource()
        {
            CreateMap<Infrastructure.Entities.Source, Core.Models.Source>().ReverseMap();

        }
    }
}
