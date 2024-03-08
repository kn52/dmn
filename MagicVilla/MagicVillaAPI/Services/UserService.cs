using MagicVillaAPI.Mappers;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Models.Responses;
using MagicVillaAPI.Repositories;
using MagicVillaAPI.Utilities.Jwt;
using System.Net;

namespace MagicVillaAPI.Services
{
    public class UserService
    {
        private readonly IConfiguration _config;
        private readonly UserRepository _userRepository;
        private readonly RoleRepository roleRepository;
        private readonly JwtTokenGeneration _securityToken;

        public UserService(IConfiguration config, UserRepository userRepository, JwtTokenGeneration securityToken, RoleRepository roleRepository)
        {
            _config = config;
            _userRepository = userRepository;
            _securityToken = securityToken;
            this.roleRepository = roleRepository;
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
                _result.Message = ex.Message;
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
                _result.Message = ex.Message;
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
                    token = await _securityToken.GenerateToken(user, _config["SecretKey"]).ConfigureAwait(false);
                    var resp = UserMapper.ConvertLocalUserToLoginResponse(user, token);
                    _result.Result = resp;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _result.IsSuccess = false;
                _result.StatusCode = HttpStatusCode.BadRequest;
                _result.Message = ex.Message;
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
                    var role = await roleRepository.GetRoleById(entity.RoleId).ConfigureAwait(false);
                    var request = UserMapper.ConvertRegistrationToLocalUser(entity);
                    request.RoleId = role.Id;
                    request.Role = new UserRole()
                    {
                        Id = role.Id,
                        Name = role.Name,
                        CreatedBy = role.CreatedBy,
                    };
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
                _result.Message = ex.Message;
                _result.Result = entity;
            }
            return _result;
        }
    }
}
