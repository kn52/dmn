using Microsoft.AspNetCore.Mvc;
using VillaService;

namespace MagicVilla_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly VillaServiceClient _service;
        public HomeController(VillaServiceClient service)
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
