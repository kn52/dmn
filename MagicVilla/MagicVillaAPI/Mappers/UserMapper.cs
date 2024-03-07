using MagicVillaAPI.Models.DAO;
using MagicVillaAPI.Models.DTO;
using Microsoft.IdentityModel.Tokens;

namespace MagicVillaAPI.Mappers
{
    public class UserMapper
    {
        public static LocalUser ConvertRegistrationToLocalUser(RegistrationRequestDTO _object)
        {
            return new LocalUser()
            {
                Name = _object.Name,
                UserName = _object.UserName,
                Password = _object.Password,
                Role = new UserRole()
                {
                    Id = string.IsNullOrEmpty(_object.RoleId) ? Guid.Empty : new Guid(_object.RoleId),
                    Name = _object.Name
                }
            };
        }
        public static RegistrationRequestDTO ConvertLocalUserToRegistration(LocalUser _object)
        {
            return new RegistrationRequestDTO()
            {
                Id = _object.Id,
                Name = _object.Name,
                UserName = _object.UserName,
                Password = _object.Password,
                RoleId = _object.Role.Id.ToString(),
                RoleName = _object.Role.Name
            };
        }
        public static LoginResponseDTO ConvertLocalUserToLoginResponse(LocalUser _object, string token)
        {
            return new LoginResponseDTO()
            {
                User = new LocalUser()
                {
                    Id = _object.Id,
                    Name = _object.Name,
                    UserName = _object.UserName,
                    Password = _object.Password,
                    Role = _object.Role
                },
                Token = token ?? string.Empty
            };
        }
    }
}
