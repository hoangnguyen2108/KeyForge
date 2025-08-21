using AutoMapper;
using KeyForge.DTO;
using KeyForge.Model;

namespace KeyForge.Configuration
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<ApiKeyClass, ApiKeyDTO>().ReverseMap();

        }
    }
}
