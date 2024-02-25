using MagicVillaAPI.Constants;
using MagicVillaAPI.Data;
using MagicVillaAPI.DTO;
using MagicVillaAPI.Logger;
using MagicVillaAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace VillaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogging _logging;

        public VillaAPIController(ILogging logging)
        {
            _logging = logging;
        }

        [HttpGet("GetVillaList", Name = "GetVillaList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logging.Log(ConstantValues.INFO, "Get all villas");
            return Ok(VillaList.Villas);
        }
        [HttpGet("GetVillaById/id:int", Name = "GetVillaById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            _logging.Log(ConstantValues.INFO, "Get specific villas" + id);
            return Ok(VillaList.Villas.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost("CreateVilla", Name = "CreateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villa)
        {
            if (villa == null)
            {
                return BadRequest(villa);
            }
            if (villa.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villa.Id = VillaList.Villas.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            return CreatedAtRoute("GetVilla", new { id = villa.Id }, villa);
        }

        [HttpDelete("DeleteVilla/id:int", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> DeleteVilla(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var villa = VillaList.Villas.FirstOrDefault(x => x.Id == id);
            VillaList.Villas.Remove(villa);
            return NoContent();
        }

        
        [HttpPut("UpdateVilla/id:int", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> UpdateVilla(int id, [FromBody] VillaDTO villaDto)
        {
            if (villaDto == null || id == 0)
            {
                return BadRequest(villaDto);
            }
            var villa = VillaList.Villas.OrderByDescending(x => x.Id == id).FirstOrDefault();
            if (villaDto == null)
            {
                return BadRequest();
            }
            if (!string.IsNullOrEmpty(villaDto.Name) && villa.Name != villaDto.Name)
            {
                villa.Name = villaDto.Name;
            }
            if (villaDto.Occupancy > 0 && villa.Occupancy != villaDto.Occupancy)
            {
                villa.Occupancy = villaDto.Occupancy;
            }
            if (villaDto.Sqft > 0 && villa.Sqft != villaDto.Sqft)
            {
                villa.Sqft = villaDto.Sqft;
            }

            return Ok();
        }

        [HttpPatch("UpdatePartialVilla/id:int", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> UpdatePartialVilla(int id, [FromBody] JsonPatchDocument<VillaDTO> patchVillaDto)
        {
            if (patchVillaDto == null|| id == 0)
            {
                return BadRequest(patchVillaDto);
            }
            var villa = VillaList.Villas.OrderByDescending(x => x.Id == id).FirstOrDefault();
            if (villa == null)
            {
                return BadRequest();
            }
            patchVillaDto.ApplyTo(villa, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }
    }
}
