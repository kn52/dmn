using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Models.DTO
{
    public class VillaNumberCreateDTO
    {
        public string? Id { get; set; }
        [Required]
        public string VillaNo { get; set; }
        public string? SpecialDetails { get; set; }
        public string? VillaId { get; set; }
    }
}
