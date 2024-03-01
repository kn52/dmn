using MagicVillaAPI.Models.DAO;
using System.ComponentModel.DataAnnotations;

namespace MagicVillaAPI.Models.DTO
{
    public class VillaNumberDTO
    {
        public string Id { get; set; }
        public string SpecialDetails { get; set; }
        public string CreatedDateTime { get; set; }
        public string UpdatedDateTime { get; set; }
        public Guid VillaId { get; set; }
        [Required]
        public int VillaNo { get; set; }
        public Villa Villa { get; set; }
    }
}
