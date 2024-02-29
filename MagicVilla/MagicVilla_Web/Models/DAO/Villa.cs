using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MagicVilla_Web.Models.Model;

namespace MagicVilla_Web.Models.DAO
{
    public class Villa : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int Rate { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
        public string CreatedDateTime { get; set; }
        public string UpdatedDateTime { get; set; }
    }
}
