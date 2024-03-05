using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MagicVillaAPI.Models.Model;

namespace MagicVillaAPI.Models.DAO
{
    [Table("villa_numbers")]
    public class VillaNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int VillaNo { get; set; } 
        public string? SpecialDetails { get; set; } = string.Empty;
        public string? CreatedDateTime { get; set; } = string.Empty;
        public string? UpdatedDateTime { get; set; } = string.Empty;

        [ForeignKey("Villa")]
        public Guid VillaId { get; set; }   
        public Villa? Villa { get; set; }           
    }
}
