using AutoMapper;
using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;

namespace MagicVillaAPI.Mappers
{
    public class MapperConfig
    {
        public UserRole ConvertUserRoleDtoToUserRole(UserRoleDTO user)
        {
            return new UserRole()
            {
                Id = string.IsNullOrEmpty(user.Id) ? new Guid() : new Guid(user.Id),
                Name = user.Name,
                CreatedBy = user.CreatedBy
            };
        }
        public UserRoleDTO ConvertUserRoleToUserRoleDto(UserRole user)
        {
            return new UserRoleDTO()
            {
                Id = user.Id != null ? user.Id.ToString() : string.Empty,
                Name = user.Name,
                CreatedBy = user.CreatedBy
            };
        }
    }
}
