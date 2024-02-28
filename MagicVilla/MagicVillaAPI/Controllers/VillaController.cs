using MagicVillaAPI.Constants;
using MagicVillaAPI.Logger;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace VillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogging _logging;
        private readonly MagicVillaService _magicVillaService;

        public VillaController(ILogging logging, MagicVillaService magicVillaService)
        {
            _logging = logging;
            _magicVillaService = magicVillaService;
        }

        [HttpGet("GetVillaList", Name = "GetVillaList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<VillaDTO>>> GetVillas()
        {
            _logging.Log(ConstantValues.INFO, "Get all villas");
            var _result = await _magicVillaService.GetVillas().ConfigureAwait(false);
            if (_result == null)
            {
                return BadRequest(_result);
            }
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
            if (_result == null)
            {
                return BadRequest(_result);
            }
            return Ok(_result);
        }

        [HttpPost("CreateVilla", Name = "CreateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaDTO villa)
        {
            if (villa == null)
            {
                return BadRequest(villa);
            }
            if (villa.Id == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var _result = await _magicVillaService.CreateVilla(villa).ConfigureAwait(false);
            if (_result == null)
            {
                return BadRequest(villa);
            }
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
            if (_result == null)
            {
                return BadRequest(id);
            }
            return Ok(_result);
        }

        [HttpPut("UpdateVilla/id:string", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VillaDTO>> UpdateVilla(string id, [FromBody] VillaDTO villaDto)
        {
            if (villaDto == null || string.IsNullOrEmpty(id))
            {
                return BadRequest(villaDto);
            }
            var _result = await _magicVillaService.UpdateVilla(id, villaDto).ConfigureAwait(false);
            if (_result == null)
            {
                return BadRequest(villaDto);
            }
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
            var _result = await _magicVillaService.UpdatePartialVilla(id, patchVillaDto).ConfigureAwait(false);
            if (_result == null)
            {
                return BadRequest(patchVillaDto);
            }
            return Ok(_result);
        }
    }
}
