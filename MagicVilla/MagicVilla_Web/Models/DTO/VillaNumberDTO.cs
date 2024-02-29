using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Models.DTO
{
    public class VillaNumberDTO
    {
        public string Id { get; set; }
        [Required]
        public int VillaNo { get; set; }
        public Guid VillaId { get; set; }
        public string SpecialDetails { get; set; }
        public string CreatedDateTime { get; set; }
        public string UpdatedDateTime { get; set; }
    }
}
