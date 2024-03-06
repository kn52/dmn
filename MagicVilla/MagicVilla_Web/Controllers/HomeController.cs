using Microsoft.AspNetCore.Mvc;
using MagicVillaServiceJ;

namespace MagicVilla_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly MagicVillaServiceJClient _service;
        public HomeController(MagicVillaServiceJClient service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<VillaDTO> villas = new();

            var response = await _service.GetVillaListAsync().ConfigureAwait(false);
            if (response != null && response.Result != null && response.IsSuccess)
            {
                villas = response.Result.ToList();
            }
            return View(villas);
        }
    }
}
