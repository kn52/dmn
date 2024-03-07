using MagicVillaAPI.Models.DAO;

namespace MagicVillaAPI.Models.DTO
{
    public class RegistrationRequestDTO
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}
