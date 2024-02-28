using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MagicVillaAPI.Models.Model;

namespace MagicVillaAPI.Models.DAO
{
    [Table("villa_numbers")]
    public class VillaNumber: IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
        public string CreatedDateTime { get; set; }
        public string UpdatedDateTime { get; set; }
    }
}
