using MagicVillaAPI.Models.DTO;
using MagicVillaAPI.Models.Responses;
using MagicVillaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RoleController : ControllerBase
    {
        private readonly RoleService roleService;
        public RoleController(RoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpPost("GetAllRoles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResponse<List<UserRoleDTO>>> GetAllUsers()
        {
            var response = new ApiResponse<List<UserRoleDTO>>();
            try
            {
                response = await roleService.GetAllRoles().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Something went wrong.";
                response.Result = null;
            }
            return response;
        }

        [HttpPost("GetRoleById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResponse<UserRoleDTO>> GetRoleById(string id)
        {
            var response = new ApiResponse<UserRoleDTO>();
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Invalid request.";
                    response.Result = null;
                }
                response = await roleService.GetRoleById(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Something went wrong.";
                response.Result = null;
            }
            return response;
        }

        [HttpPost("CreateRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResponse<UserRoleDTO>> CreateRole(UserRoleDTO entity)
        {
            var response = new ApiResponse<UserRoleDTO>();
            try
            {
                if (string.IsNullOrEmpty(entity.Name))
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Invalid request.";
                    response.Result = null;
                }
                response = await roleService.CreateRole(entity).ConfigureAwait(false);
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

        [HttpPost("UpdateRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResponse<UserRoleDTO>> UpdateRole(UserRoleDTO entity)
        {
            var response = new ApiResponse<UserRoleDTO>();
            try
            {
                if (string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.Id))
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Invalid request.";
                    response.Result = null;
                }
                response = await roleService.UpdateRole(entity).ConfigureAwait(false);
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
        
        [HttpPost("DeleteRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ApiResponse<UserRoleDTO>> DeleteRole(string Id)
        {
            var response = new ApiResponse<UserRoleDTO>();
            try
            {
                if (string.IsNullOrEmpty(Id))
                {
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Invalid request.";
                    response.Result = null;
                }
                response = await roleService.DeleteRole(Id).ConfigureAwait(false);
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
