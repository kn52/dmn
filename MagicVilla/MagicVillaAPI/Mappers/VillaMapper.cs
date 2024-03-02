using MagicVillaAPI.Constants;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;

namespace MagicVillaAPI.Mappers
{
    public static class VillaMapper
    {
        public static Villa ConvertToVilla(VillaDTO _object)
        {
            return new Villa()
            {
                Id = string.IsNullOrEmpty(_object.Id) ? new Guid() : new Guid(_object.Id),
                Name = _object.Name,
                Rate = _object.Rate,
                Sqft = _object.Sqft,
                Occupancy = _object.Occupancy,
                Details = _object.Details,
                Amenity = _object.Amenity,
                ImageUrl = _object.ImageUrl,
            };
        }
        public static VillaDTO ConvertToVillaDto(Villa _object)
        {
            return new VillaDTO()
            {
                Id = _object.Id.ToString(),
                Name = _object.Name,
                Rate = _object.Rate,
                Sqft = _object.Sqft,
                Occupancy = _object.Occupancy,
                Details = _object.Details,
                Amenity = _object.Amenity,
                ImageUrl = _object.ImageUrl,
                CreatedDateTime = _object.CreatedDateTime,
                UpdatedDateTime = _object.UpdatedDateTime
            };
        }
    }
}
