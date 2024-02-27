using MagicVillaAPI.Constants;
using MagicVillaAPI.Data;
using MagicVillaAPI.Logger;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Services.DBContext;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace VillaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogging _logging;
        private readonly CommonDBContext _db;

        public VillaAPIController(ILogging logging, CommonDBContext db)
        {
            _logging = logging;
            _db = db;
        }

        [HttpGet("GetVillaList", Name = "GetVillaList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logging.Log(ConstantValues.INFO, "Get all villas");
            return Ok(_db.Villas.ToList());
        }
        [HttpGet("GetVillaById/id:string", Name = "GetVillaById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(string id)
        {
            _logging.Log(ConstantValues.INFO, "Get specific villas" + id);
            return Ok(_db.Villas.FirstOrDefault(x => x.Id == new Guid(id)));
        }

        [HttpPost("CreateVilla", Name = "CreateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villa)
        {
            if (_db.Villas.FirstOrDefault(x => x.Name == villa.Name) != null)
            {
                return BadRequest("Villa already exists");
            }
            if (villa == null)
            {
                return BadRequest(villa);
            }
            if (villa.Id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            _db.Villas.Add(new Villa()
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
            });
            _db.SaveChanges();
            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
        }

        [HttpDelete("DeleteVilla/id:string", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> DeleteVilla(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var villa = _db.Villas.FirstOrDefault(x => x.Id == new Guid(id));
            _db.Villas.Remove(villa);
            _db.SaveChanges();
            return NoContent();
        }


        [HttpPut("UpdateVilla/id:string", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> UpdateVilla(string id, [FromBody] VillaDTO villaDto)
        {
            if (villaDto == null || string.IsNullOrEmpty(id))
            {
                return BadRequest(villaDto);
            }
            _db.Villas.Add(new Villa()
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
            });
            _db.SaveChanges();

            return Ok();
        }

        [HttpPatch("UpdatePartialVilla/id:string", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> UpdatePartialVilla(string id, [FromBody] JsonPatchDocument<VillaDTO> patchVillaDto)
        {
            if (patchVillaDto == null || string.IsNullOrEmpty(id))
            {
                return BadRequest(patchVillaDto);
            }
            var villa = _db.Villas.OrderByDescending(x => x.Id == new Guid(id)).FirstOrDefault();
            if (villa == null)
            {
                return BadRequest();
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
            patchVillaDto.ApplyTo(model, ModelState);
            _db.Villas.Update(new Villa()
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
            });
            _db.SaveChanges();
            return Ok();
        }
    }
}
