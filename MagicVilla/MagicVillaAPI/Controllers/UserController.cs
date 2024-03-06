using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Models.Responses;
using MagicVillaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("IsValidUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResponse<bool>> IsValidUser(LoginRequestDTO loginRequestDTO)
        {
            var response = new ApiResponse<bool>();
            try
            {
                if (string.IsNullOrEmpty(loginRequestDTO.UserName) || string.IsNullOrEmpty(loginRequestDTO.Password))
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Invalid request.";
                    response.Result = false;
                }
                response = await _userService.IsValidUser(loginRequestDTO).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Invalid User.";
                response.Result = false;
            }
            return response;
        }
        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResponse<LoginResponseDTO>> Login(LoginRequestDTO loginRequestDTO)
        {
            var response = new ApiResponse<LoginResponseDTO>();
            try
            {
                if (string.IsNullOrEmpty(loginRequestDTO.UserName) || string.IsNullOrEmpty(loginRequestDTO.Password))
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Invalid username or password.";
                    response.Result = null;
                }
                response = await _userService.Login(loginRequestDTO).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Invalid User.";
                response.Result = null;
            }
            return response;
        }
        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResponse<RegistrationRequestDTO>> Register(RegistrationRequestDTO entity)
        {
            var response = new ApiResponse<RegistrationRequestDTO>();
            try
            {
                if (string.IsNullOrEmpty(entity.UserName) 
                    || string.IsNullOrEmpty(entity.Password)
                    || string.IsNullOrEmpty(entity.Name)
                    || string.IsNullOrEmpty(entity.Role))
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Invalid request.";
                    response.Result = null;
                }
                response = await _userService.Register(entity).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Something went wrong.";
            }
            return response;
        }

    }
}
