using MagicVillaAPI.Constants;
using MagicVillaAPI.EntityContext.DBContext;
using MagicVillaAPI.EntityContext.DBContext.Common;
using MagicVillaAPI.Logger;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace VillaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogging _logging;
        private readonly CommonDBContext _db;
        private readonly MagicVIllaService _magicVillaService;

        public VillaAPIController(ILogging logging, CommonDBContext db, MagicVIllaService magicVIllaService)
        {
            _logging = logging;
            _db = db;
            _magicVillaService = magicVIllaService;
        }

        [HttpGet("GetVillaList", Name = "GetVillaList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            _logging.Log(ConstantValues.INFO, "Get all villas");
            var _result = await _magicVillaService.GetVillas().ConfigureAwait(false);
            return Ok(_result);
        }
        [HttpGet("GetVillaById/id:string", Name = "GetVillaById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> GetVilla(string id)
        {
            _logging.Log(ConstantValues.INFO, "Get specific villas" + id);
            var _result = await _magicVillaService.GetVilla(id).ConfigureAwait(false);
            return Ok(_result);
        }

        [HttpPost("CreateVilla", Name = "CreateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaDTO villa)
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
            var _result = await _magicVillaService.CreateVilla(villa).ConfigureAwait(false);
            return Ok(_result);
        }

        [HttpDelete("DeleteVilla/id:string", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> DeleteVilla(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var _result = await _magicVillaService.DeleteVilla(id).ConfigureAwait(false);
            return Ok(_result);
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
            var _result = _magicVillaService.UpdateVilla(id, villaDto);
            return Ok(_result);
        }

        [HttpPatch("UpdatePartialVilla/id:string", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VillaDTO>> UpdatePartialVilla(string id, [FromBody] JsonPatchDocument<VillaDTO> patchVillaDto)
        {
            if (patchVillaDto == null || string.IsNullOrEmpty(id))
            {
                return BadRequest(patchVillaDto);
            }
            var villa = _db.Villas.AsNoTracking().OrderByDescending(x => x.Id == new Guid(id)).FirstOrDefault();
            if (villa == null)
            {
                return BadRequest();
            }
            var _result = await _magicVillaService.UpdatePartialVilla(villa, patchVillaDto).ConfigureAwait(false);
            return Ok(_result);
        }
    }
}
