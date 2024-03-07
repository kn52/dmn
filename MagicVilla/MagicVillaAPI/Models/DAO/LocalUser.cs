using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVillaAPI.Models.DAO
{
    [Table("local_user")]
    public class LocalUser
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public UserRole Role { get; set; }
    }
}
