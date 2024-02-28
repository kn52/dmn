using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.EntityContext.DBContext.Common;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MagicVillaAPI.Services
{
    public class MagicVillaService : CommonContextIns
    {
        public MagicVillaService(CommonDBContext _db) : base(_db) { }

        public async Task<List<VillaDTO>> GetVillas()
        {
            var villas = _db.Villas;
            if (villas == null)
            {
                return null;
            }
            var model = villas.Select(villa => new VillaDTO()
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Amenity = villa.Amenity,
                CreatedDateTime = villa.CreatedDateTime,
                ImageUrl = villa.ImageUrl,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                Sqft = villa.Sqft,
                UpdatedDateTime = villa.UpdatedDateTime,
            }).ToList();
            return model;
        }
        public async Task<VillaDTO> GetVilla(string id)
        {
            var villa = _db.Villas.FirstOrDefault(x => x.Id == new Guid(id));
            if (villa == null)
            {
                return new VillaDTO();
            }
            var model = new VillaDTO()
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Amenity = villa.Amenity,
                CreatedDateTime = villa.CreatedDateTime,
                ImageUrl = villa.ImageUrl,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                Sqft = villa.Sqft,
                UpdatedDateTime = villa.UpdatedDateTime,
            };
            return model;
        }
        public async Task<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            if (_db.Villas.FirstOrDefault(x => x.Name == villaDTO.Name) != null)
            {
                return null;
            }
            var insertModel = new Villa()
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Amenity = villaDTO.Amenity,
                CreatedDateTime = villaDTO.CreatedDateTime,
                ImageUrl = villaDTO.ImageUrl,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft,
                UpdatedDateTime = villaDTO.UpdatedDateTime,
            };
            _db.Villas.Add(insertModel);
            _db.SaveChanges();
            return villaDTO;
        }
        public async Task<VillaDTO> DeleteVilla(string id)
        {
            var villa = _db.Villas.FirstOrDefault(x => x.Id == new Guid(id));
            if (villa == null)
            {
                return null;
            }
            _db.Villas.Remove(villa);
            _db.SaveChanges();

            var model = new VillaDTO()
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Amenity = villa.Amenity,
                CreatedDateTime = villa.CreatedDateTime,
                ImageUrl = villa.ImageUrl,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                Sqft = villa.Sqft,
                UpdatedDateTime = villa.UpdatedDateTime,
            };
            return model;
        }
        public async Task<VillaDTO> UpdateVilla(string id, [FromBody] VillaDTO villaDto)
        {
            var updatedModel = new Villa()
            {
                Id = villaDto.Id,
                Name = villaDto.Name,
                Details = villaDto.Details,
                Amenity = villaDto.Amenity,
                CreatedDateTime = villaDto.CreatedDateTime,
                ImageUrl = villaDto.ImageUrl,
                Occupancy = villaDto.Occupancy,
                Rate = villaDto.Rate,
                Sqft = villaDto.Sqft,
                UpdatedDateTime = villaDto.UpdatedDateTime,
            };
            _db.Villas.Update(updatedModel);
            _db.SaveChanges();
            return villaDto;
        }
        public async Task<VillaDTO> UpdatePartialVilla(string id, [FromBody] JsonPatchDocument<VillaDTO> patchVillaDto)
        {
            var villa = _db.Villas.AsNoTracking().OrderByDescending(x => x.Id == new Guid(id)).FirstOrDefault();
            if (villa == null)
            {
                return null;
            }
            VillaDTO model = new()
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Amenity = villa.Amenity,
                CreatedDateTime = villa.CreatedDateTime,
                ImageUrl = villa.ImageUrl,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                Sqft = villa.Sqft,
                UpdatedDateTime = villa.UpdatedDateTime,
            };
            patchVillaDto.ApplyTo(model);
            var updatedModel = new Villa()
            {
                Id = model.Id,
                Name = model.Name,
                Details = model.Details,
                Amenity = model.Amenity,
                CreatedDateTime = model.CreatedDateTime,
                ImageUrl = model.ImageUrl,
                Occupancy = model.Occupancy,
                Rate = model.Rate,
                Sqft = model.Sqft,
                UpdatedDateTime = model.UpdatedDateTime,
            };
            _db.Villas.Update(updatedModel);
            _db.SaveChanges();
            return model;
        }
    }
}
