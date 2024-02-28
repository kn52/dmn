using AutoMapper;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;

namespace MagicVillaAPI.Mappers
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Villa, VillaDTO>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id.ToString()));
            CreateMap<VillaDTO, Villa>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => string.IsNullOrWhiteSpace(src.Id) ? (Guid?)null : Guid.Parse(src.Id)));
        }
    }
}
