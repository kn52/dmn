using MagicVillaAPI.Constants;
using MagicVillaAPI.Logger;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Models.Responses;
using MagicVillaAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public async Task<ApiResponse<List<VillaDTO>>> GetVillas()
        {
            var _response = new ApiResponse<List<VillaDTO>>();
            _logging.Log(ConstantValues.INFO, "Get all villas");
            var _result = await _magicVillaService.GetVillas().ConfigureAwait(false);
            if (_result == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid villa id.";
            }
            _response.Result = _result;
            return _response;
        }
        [HttpGet("GetVillaById/id:string", Name = "GetVillaById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResponse<VillaDTO>> GetVilla(string id)
        {
            var _response = new ApiResponse<VillaDTO>();
            _logging.Log(ConstantValues.INFO, "Get specific villas" + id);
            var _result = await _magicVillaService.GetVilla(id).ConfigureAwait(false);
            if (_result == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid villa id.";
            }
            _response.Result = _result;
            return _response;
        }

        [HttpPost("CreateVilla", Name = "CreateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResponse<VillaDTO>> CreateVilla([FromBody] VillaDTO villa)
        {
            var _response = new ApiResponse<VillaDTO>();
            if (villa == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid request.";
                _response.Result = villa;
            }
            var _result = await _magicVillaService.CreateVilla(villa).ConfigureAwait(false);
            if (_result == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = ConstantValues.ERROR;
                _response.Result = villa;
            }
            _response.Result = _result;
            return _response;
        }

        [HttpDelete("DeleteVilla/id:string", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResponse<VillaDTO>> DeleteVilla(string id)
        {
            var _response = new ApiResponse<VillaDTO>();
            if (string.IsNullOrEmpty(id))
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid villa id.";
                _response.Result = new VillaDTO() { Id = id };
            }
            var _result = await _magicVillaService.DeleteVilla(id).ConfigureAwait(false);
            if (_result == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid villa id.";
                _response.Result = new VillaDTO() { Id = id};
            }
            _response.Result = _result;
            return _response;
        }

        [HttpPut("UpdateVilla/id:string", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ApiResponse<VillaDTO>> UpdateVilla(string id, [FromBody] VillaDTO villaDto)
        {
            var _response = new ApiResponse<VillaDTO>();
            if (villaDto == null || string.IsNullOrEmpty(id))
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid villa id or request.";
                _response.Result = villaDto;
            }
            var _result = await _magicVillaService.UpdateVilla(id, villaDto).ConfigureAwait(false);
            if (_result == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid villa id.";
                _response.Result = villaDto;
            }
            _response.Result = _result;
            return _response;
        }

        [HttpPatch("UpdatePartialVilla/id:string", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ApiResponse<VillaDTO>> UpdatePartialVilla(string id, [FromBody] JsonPatchDocument<VillaDTO> patchVillaDto)
        {
            var _response = new ApiResponse<VillaDTO>();
            if (patchVillaDto == null || string.IsNullOrEmpty(id))
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid villa id or request.";
                _response.Result = null;
            }
            var _result = await _magicVillaService.UpdatePartialVilla(id, patchVillaDto).ConfigureAwait(false);
            if (_result == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid villa id.";
                _response.Result = null;
            }
            _response.Result = _result;
            return _response;
        }
    }
}
