using AutoMapper;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Models.Responses;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _service;
        private readonly IMapper _mapper;
        public VillaController(IVillaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<VillaDTO> villas = new();

            var response = await _service.GetAllAsync<APIResponse<List<VillaDTO>>>();
            if (response != null && response.Result != null && response.IsSuccess)
            {
                villas = response.Result;
            }
            return View(villas);
        }
        public async Task<IActionResult> ViewCreate(VillaDTO model)
        {
            return View("Create", model);
        }
        public async Task<IActionResult> Create(VillaDTO model)
        {
            var response = await _service.CreateAsync<APIResponse<VillaDTO>>(model);
            if (response != null && response.IsSuccess)
            {
                return Redirect("/Villa");
            }
            return View(model);
        }
        public async Task<IActionResult> Details(string Id)
        {
            VillaDTO villas = new();
            var response = await _service.GetAsync<APIResponse<VillaDTO>>(Id);
            if (response != null && response.IsSuccess)
            {
                villas = response.Result;
            }
            return View(villas);
        }
        public async Task<IActionResult> Delete(string Id)
        {
            VillaDTO villas = new();
            var response = await _service.DeleteAsync<APIResponse<VillaDTO>>(Id);
            if (response != null && response.IsSuccess)
            {
                villas = response.Result;
                return Redirect("/Villa");
            }
            return View(villas);
        }
        public async Task<IActionResult> ViewUpdate(VillaDTO model)
        {
            var response = await _service.GetAsync<APIResponse<VillaDTO>>(model.Id);
            if (response != null && response.IsSuccess)
            {
                model = response.Result;
            }
            return View("Update", model);
        }
        public async Task<IActionResult> Update(VillaDTO model)
        {
            var response = await _service.UpdateAsync<APIResponse<VillaDTO>>(model);
            if (response != null && response.IsSuccess)
            {
                return Redirect("/Villa");
            }
            return View(model);
        }
    }
}
