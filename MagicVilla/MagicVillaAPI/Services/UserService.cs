using MagicVillaAPI.Mappers;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Models.Responses;
using MagicVillaAPI.Repositories;
using System.Net;

namespace MagicVillaAPI.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ApiResponse<bool>> IsValidUser(LoginRequestDTO loginRequestDTO)
        {
            var _result = new ApiResponse<bool>();
            try
            {
                var user = await _userRepository.IsValidUser(loginRequestDTO.UserName, loginRequestDTO.Password).ConfigureAwait(false);
                if (user == null)
                {
                    _result.IsSuccess = false;
                    _result.StatusCode = HttpStatusCode.BadRequest;
                    _result.Message = "Invalid User.";
                    _result.Result = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _result;
        }
        public async Task<ApiResponse<LoginResponseDTO>> Login(LoginRequestDTO loginRequestDTO)
        {
            var _result = new ApiResponse<LoginResponseDTO>();
            try
            {
                var (user, token) = await _userRepository.Login(loginRequestDTO.UserName, loginRequestDTO.Password).ConfigureAwait(false);
                if (user == null)
                {
                    _result.IsSuccess = false;
                    _result.StatusCode = HttpStatusCode.BadRequest;
                    _result.Message = "Something went wrong.";
                    _result.Result = null;
                }
                else
                {
                    var resp = UserMapper.ConvertLocalUserToLoginResponse(user, token);
                    _result.Result = resp;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _result.IsSuccess = false;
                _result.StatusCode = HttpStatusCode.BadRequest;
                _result.Message = "Something went wrong.";
                _result.Result = null;
            }
            return _result;
        }
        public async Task<ApiResponse<RegistrationRequestDTO>> Register(RegistrationRequestDTO entity)
        {
            var _result = new ApiResponse<RegistrationRequestDTO>();
            try
            {
                var IsValidUser = false;
                if (!IsValidUser)
                {
                    var request = UserMapper.ConvertRegistrationToLocalUser(entity);
                    var _success = await _userRepository.Register(request).ConfigureAwait(false);
                    if (!_success)
                    {
                        _result.IsSuccess = false;
                        _result.StatusCode = HttpStatusCode.BadRequest;
                        _result.Message = "Something went wrong.";
                        _result.Result = entity;
                    }
                    else
                    {
                        _result.Result = entity;
                    } 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _result.IsSuccess = false;
                _result.StatusCode = HttpStatusCode.BadRequest;
                _result.Message = "Something went wrong.";
                _result.Result = entity;
            }
            return _result;
        }
    }
}
