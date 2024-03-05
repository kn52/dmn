using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Models.DTO
{
    public class VillaCreateDTO
    {
        public string? Id { get; set; }
        [Required]
        public string? Name { get; set; } = string.Empty;
        public string? Details { get; set; } = string.Empty;
        public int? Rate { get; set; }
        public int? Sqft { get; set; }
        public int? Occupancy { get; set; }
        public string? ImageUrl { get; set; }
        public string? Amenity { get; set; }
    }
}
