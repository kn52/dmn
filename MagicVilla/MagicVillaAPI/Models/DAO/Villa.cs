using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MagicVillaAPI.Models.Model;

namespace MagicVillaAPI.Models.DAO
{
    [Table("Villa")]
    public class Villa
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Details { get; set; } = string.Empty;
        public int? Rate { get; set; } = 0;
        public int? Sqft { get; set; } = 0;
        public int? Occupancy { get; set; } = 0;
        public string? ImageUrl { get; set; } = string.Empty;
        public string? Amenity { get; set; } = string.Empty;
        public string? CreatedDateTime { get; set; } = string.Empty;
        public string? UpdatedDateTime { get; set; } = string.Empty;
    }
}
