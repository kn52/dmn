using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;

namespace MagicVillaAPI.Mappers
{
    public static class VillaNumberMapper
    {
        public static VillaNumber ConvertToVillaNumber(VillaNumberDTO _object)
        {
            var v = new VillaNumber()
            {
                Id = string.IsNullOrEmpty(_object.Id) ? Guid.Empty : new Guid(_object.Id),
                VillaNo = Convert.ToInt32(_object.VillaNo),
                SpecialDetails = _object.SpecialDetails,
                VillaId = string.IsNullOrEmpty(_object.VillaId) ? Guid.Empty : new Guid(_object.VillaId),
                Villa = _object.Villa,
            };
            
            return v;
        }
        public static VillaNumberDTO ConvertToVillaNumberDto(VillaNumber _object)
        {
            return new VillaNumberDTO()
            {
                Id = _object.Id.ToString(),
                VillaNo = Convert.ToString(_object.VillaNo),
                SpecialDetails = _object.SpecialDetails,
                CreatedDateTime = _object.CreatedDateTime,
                UpdatedDateTime = _object.UpdatedDateTime,
                VillaId = _object.VillaId.ToString(),
                Villa = _object.Villa,
            };
        }
    }
}
