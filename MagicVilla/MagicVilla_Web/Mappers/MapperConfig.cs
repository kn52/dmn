using AutoMapper;
using MagicVilla_Web.Models.DAO;
using MagicVilla_Web.Models.DTO;
using System;

namespace MagicVilla_Web.Mappers
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Villa, VillaDTO>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id.ToString()));
            CreateMap<VillaDTO, Villa>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => string.IsNullOrWhiteSpace(src.Id) ? (Guid?)null : Guid.Parse(src.Id)));

            CreateMap<VillaNumber, VillaNumberDTO>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id.ToString()));
            CreateMap<VillaNumberDTO, VillaNumber>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => string.IsNullOrWhiteSpace(src.Id) ? (Guid?)null : Guid.Parse(src.Id)));
        }
    }
}
