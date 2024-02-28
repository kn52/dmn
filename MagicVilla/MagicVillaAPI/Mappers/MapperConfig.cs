using AutoMapper;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;

namespace MagicVillaAPI.Mappers
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Villa, VillaDTO>().ReverseMap();
        }
    }
}
