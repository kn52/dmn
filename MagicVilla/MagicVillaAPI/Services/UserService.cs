using MagicVillaAPI.Mappers;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Models.Responses;
using MagicVillaAPI.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace MagicVillaAPI.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ApiResponse<List<RegistrationRequestDTO>>> GetValidUser()
        {
            var _result = new ApiResponse<List<RegistrationRequestDTO>>();
            try
            {
                var users = await _userRepository.GetValidUser().ConfigureAwait(false);
                if (users == null)
                {
                    _result.IsSuccess = false;
                    _result.StatusCode = HttpStatusCode.BadRequest;
                    _result.Message = "Something went wrong.";
                    _result.Result = null;
                }
                else
                {
                    var userlist = users.Select(user => UserMapper.ConvertLocalUserToRegistration(user)).ToList();
                    _result.Result = userlist;
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
        public async Task<ApiResponse<RegistrationRequestDTO>> GetUserById(string username, int id)
        {
            var _result = new ApiResponse<RegistrationRequestDTO>();
            try
            {
                var user = await _userRepository.GetUserById(username, id).ConfigureAwait(false);
                if (user == null)
                {
                    _result.IsSuccess = false;
                    _result.StatusCode = HttpStatusCode.BadRequest;
                    _result.Message = "Invalid User.";
                    _result.Result = null;
                }
                else
                {
                    _result.Result = UserMapper.ConvertLocalUserToRegistration(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _result.IsSuccess = false;
                _result.StatusCode = HttpStatusCode.BadRequest;
                _result.Message = "Something went wrong";
                _result.Result = null;
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
                    _result.Message = "Invalid User.";
                    _result.Result = null;
                }
                else
                {
                    var secret = "abc";
                    var tokenhandler = new JwtSecurityTokenHandler();
                    var encodesecret = Encoding.ASCII.GetBytes(secret);

                    var tokendescription = new SecurityTokenDescriptor()
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, user.Id.ToString()),
                            new Claim(ClaimTypes.Role, user.Role)
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new(new SymmetricSecurityKey(encodesecret), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var createdToken = tokenhandler.CreateToken(tokendescription);
                    token = tokenhandler.WriteToken(createdToken);
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
