using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Models.Responses;
using MagicVilla_Web.Services;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MagicVilla_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVillaService _villaService;
        public HomeController(IVillaService villaService)
        {
            _villaService = villaService;
        }

        public async Task<IActionResult> Index()
        {
            List<VillaDTO> villas = new();

            var response = await _villaService.GetAllAsync<APIResponse<List<VillaDTO>>>();
            if (response != null && response.Result != null && response.IsSuccess)
            {
                villas = response.Result;
            }
            return View(villas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
