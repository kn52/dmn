using MagicVilla_Web.Models.DAO;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Models.DTO
{
    public class VillaNumberDTO
    {
        public string? Id { get; set; }
        [Required]
        public string VillaNo { get; set; }
        public string? SpecialDetails { get; set; }
        public string? CreatedDateTime { get; set; }
        public string? UpdatedDateTime { get; set; }
        public string? VillaId { get; set; }
        public Villa? Villa { get; set; }
    }
}
