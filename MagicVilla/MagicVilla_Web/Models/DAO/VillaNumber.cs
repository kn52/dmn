using MagicVilla_Web.Models.Model;

namespace MagicVilla_Web.Models.DAO
{
    public class VillaNumber : IEntity
    {
        public Guid Id { get; set; }
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }
        public string CreatedDateTime { get; set; }
        public string UpdatedDateTime { get; set; }
        public Guid VillaId { get; set; }
        public Villa Villa { get; set; }
    }
}
