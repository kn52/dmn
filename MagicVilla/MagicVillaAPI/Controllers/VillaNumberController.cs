using MagicVillaAPI.Constants;
using MagicVillaAPI.Logger;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Models.Responses;
using MagicVillaAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        private readonly ILogging _logging;
        private readonly VillaNumberService _villaNumberService;

        public VillaNumberController(ILogging logging, VillaNumberService villaNumberService)
        {
            _logging = logging;
            _villaNumberService = villaNumberService;
        }
        [HttpGet("GetVillaNumbers", Name = "GetVillaNumbers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ApiResponse<List<VillaNumberDTO>>> GetVillaNumbers()
        {
            var _response = new ApiResponse<List<VillaNumberDTO>>();
            _logging.Log(ConstantValues.INFO, "Get all villaNumbers");
            var _result = await _villaNumberService.GetVillaNumbers().ConfigureAwait(false);
            if (_result == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = ConstantValues.ERROR;
            }
            _response.Result = _result;
            return _response;
        }
        [HttpGet("GetVillaNumberById/id:string", Name = "GetVillaNumberById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResponse<VillaNumberDTO>> GetVillaNumber(string id)
        {
            var _response = new ApiResponse<VillaNumberDTO>();
            _logging.Log(ConstantValues.INFO, "Get specific villaNumber" + id);
            var _result = await _villaNumberService.GetVillaNumber(id).ConfigureAwait(false);
            if (_result == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid villa number.";
            }
            _response.Result = _result;
            return _response;
        }

        [HttpPost("CreateVillaNumber", Name = "CreateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResponse<VillaNumberDTO>> CreateVillaNumber([FromBody] VillaNumberDTO villa)
        {
            var _response = new ApiResponse<VillaNumberDTO>();
            if (villa == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid request.";
                _response.Result = villa;
            }

            var _result = await _villaNumberService.CreateVillaNumber(villa).ConfigureAwait(false);
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

        [HttpDelete("DeleteVillaNumber/id:string", Name = "DeleteVillaNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResponse<VillaNumberDTO>> DeleteVillaNumber(string id)
        {
            var _response = new ApiResponse<VillaNumberDTO>();
            if (string.IsNullOrEmpty(id))
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid request.";
                _response.Result = new VillaNumberDTO() { VillaNo = id };
            }
            var _result = await _villaNumberService.DeleteVillaNumber(id).ConfigureAwait(false);
            if (_result == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid villa number.";
                _response.Result = new VillaNumberDTO() { VillaNo = id };
            }
            _response.Result = _result;
            return _response;
        }

        [HttpPut("UpdateVillaNumber/string:string", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ApiResponse<VillaNumberDTO>> UpdateVillaNumber(string id, [FromBody] VillaNumberDTO villaDto)
        {
            var _response = new ApiResponse<VillaNumberDTO>();
            if (villaDto == null || string.IsNullOrEmpty(id))
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid villa number or request.";
                _response.Result = villaDto;
            }
            var _result = await _villaNumberService.UpdateVillaNumber(id, villaDto).ConfigureAwait(false);
            if (_result == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid villa number.";
                _response.Result = villaDto;
            }
            _response.Result = _result;
            return _response;
        }

        [HttpPatch("UpdatePartialVillaNumber/id:string", Name = "UpdatePartialVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ApiResponse<VillaNumberDTO>> UpdatePartialVillaNumber(string id, [FromBody] JsonPatchDocument<VillaNumberDTO> patchVillaDto)
        {
            var _response = new ApiResponse<VillaNumberDTO>();
            if (patchVillaDto == null || string.IsNullOrEmpty(id))
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid villa number or request";
                _response.Result = null;
            }
            var _result = await _villaNumberService.UpdatePartialVillaNumber(id, patchVillaDto).ConfigureAwait(false);
            if (_result == null)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.Message = "Invalid villa number.";
                _response.Result = null;
            }
            _response.Result = _result;
            return _response;
        }
    }
}
