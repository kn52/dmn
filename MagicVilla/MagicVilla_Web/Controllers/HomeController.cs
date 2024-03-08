using Microsoft.AspNetCore.Mvc;
using MagicVillaServiceJ;
using MagicVilla_Uitility;
using MagicVilla_Web.HttpExtensions;

namespace MagicVilla_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly MagicVillaServiceJClient _service;
        private readonly HttpManager httpManager;

        public HomeController(MagicVillaServiceJClient service, HttpManager httpManager)
        {
            _service = service;
            this.httpManager = httpManager;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString(Constants.JWT) == null)
            {
                return Redirect("/User/ViewLogin");
            }
            List<VillaDTO> villas = new();
            var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
            _service.AddToken(token);

            var response = await _service.GetVillaListAsync().ConfigureAwait(false);
            if (response != null && response.Result != null && response.IsSuccess)
            {
                villas = response.Result.ToList();
            }
            return View(villas);
        }
    }
}
