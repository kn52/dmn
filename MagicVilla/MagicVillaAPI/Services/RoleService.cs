using MagicVillaAPI.Mappers;
using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Models.Responses;
using MagicVillaAPI.Repositories;
using System.Net;

namespace MagicVillaAPI.Services
{
    public class RoleService
    {
        private readonly RoleRepository roleRepository;
        private readonly MapperConfig mapperConfig;

        public RoleService(RoleRepository roleRepository, MapperConfig mapperConfig)
        {
            this.roleRepository = roleRepository;
            this.mapperConfig = mapperConfig;
        }

        public async Task<ApiResponse<List<UserRoleDTO>>> GetAllRoles()
        {
            var _result = new ApiResponse<List<UserRoleDTO>>();
            try
            {
                var users = await roleRepository.GetAllRoles().ConfigureAwait(false);
                if (users == null)
                {
                    _result.IsSuccess = false;
                    _result.StatusCode = HttpStatusCode.BadRequest;
                    _result.Message = "Something went wrong.";
                    _result.Result = null;
                }
                else
                {
                    var userlist = users.Select(user => mapperConfig.ConvertUserRoleToUserRoleDto(user)).ToList();
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
        public async Task<ApiResponse<UserRoleDTO>> GetRoleById(string id)
        {
            var _result = new ApiResponse<UserRoleDTO>();
            try
            {
                var user = await roleRepository.GetRoleById(id).ConfigureAwait(false);
                if (user == null)
                {
                    _result.IsSuccess = false;
                    _result.StatusCode = HttpStatusCode.BadRequest;
                    _result.Message = "Invalid Id.";
                    _result.Result = null;
                }
                else
                {
                    _result.Result = mapperConfig.ConvertUserRoleToUserRoleDto(user);
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
        public async Task<ApiResponse<UserRoleDTO>> CreateRole(UserRoleDTO userRoleDTO)
        {
            var _result = new ApiResponse<UserRoleDTO>();
            try
            {
                var request = mapperConfig.ConvertUserRoleDtoToUserRole(userRoleDTO);
                request.Id = Guid.NewGuid();
                var user = await roleRepository.CreateRole(request).ConfigureAwait(false);
                if (user == null)
                {
                    _result.IsSuccess = false;
                    _result.StatusCode = HttpStatusCode.BadRequest;
                    _result.Message = "Something went wrong.";
                    _result.Result = null;
                }
                else
                {
                    userRoleDTO.Id = request.Id.ToString();
                    _result.Result = userRoleDTO;
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
        public async Task<ApiResponse<UserRoleDTO>> DeleteRole(string id)
        {
            var _result = new ApiResponse<UserRoleDTO>();
            try
            {
                var user = await roleRepository.DeleteRole(id).ConfigureAwait(false);
                if (user == null)
                {
                    _result.IsSuccess = false;
                    _result.StatusCode = HttpStatusCode.BadRequest;
                    _result.Message = "Invalid role.";
                    _result.Result = new UserRoleDTO { Id = id };
                }
                else
                {
                    _result.Result = mapperConfig.ConvertUserRoleToUserRoleDto(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _result.IsSuccess = false;
                _result.StatusCode = HttpStatusCode.BadRequest;
                _result.Message = ex.Message;
                _result.Result = new UserRoleDTO { Id = id };
            }
            return _result;
        }
        public async Task<ApiResponse<UserRoleDTO>> UpdateRole(UserRoleDTO userRoleDTO)
        {
            var _result = new ApiResponse<UserRoleDTO>();
            try
            {
                var request = mapperConfig.ConvertUserRoleDtoToUserRole(userRoleDTO);
                var user = await roleRepository.UpdateRole(request.Id.ToString(), request).ConfigureAwait(false);
                if (user == null)
                {
                    _result.IsSuccess = false;
                    _result.StatusCode = HttpStatusCode.BadRequest;
                    _result.Message = "Something went wrong.";
                    _result.Result = null;
                }
                else
                {
                    userRoleDTO.Id = request.Id.ToString();
                    _result.Result = userRoleDTO;
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
    }
}
