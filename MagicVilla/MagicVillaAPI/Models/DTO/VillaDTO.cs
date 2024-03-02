using System.ComponentModel.DataAnnotations;

namespace MagicVillaAPI.Models.DTO
{
    public class CNO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateTime { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
    }
    public class VillaDTO
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Details { get; set; }
        public int? Rate { get; set; }
        public int? Sqft { get; set; }
        public int? Occupancy { get; set; }
        public string? ImageUrl { get; set; }
        public string? Amenity { get; set; }
        public string? CreatedDateTime { get; set; }
        public string? UpdatedDateTime { get; set; }
    }
}
