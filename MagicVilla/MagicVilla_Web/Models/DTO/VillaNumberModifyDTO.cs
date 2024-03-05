using MagicVilla_Web.Models.DAO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Models.DTO
{
    public class VillaNumberModifyDTO
    {
        public string? Id { get; set; }
        public string VillaNo { get; set; }
        public string? SpecialDetails { get; set; }
        public string? VillaId { get; set; }
        public List<SelectListItem>? VillaList { get; set; }
    }
}
