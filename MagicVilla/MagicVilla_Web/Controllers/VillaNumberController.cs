using AutoMapper;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Models.Responses;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _service;
        private readonly IMapper _mapper;
        public VillaNumberController(IVillaNumberService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<VillaNumberDTO> villas = new();

            var response = await _service.GetAllAsync<APIResponse<List<VillaNumberDTO>>>();
            if (response != null && response.Result != null && response.IsSuccess)
            {
                villas = response.Result;
            }
            return View(villas);
        }
        public async Task<IActionResult> ViewCreate(VillaNumberDTO model)
        {
            return View("Create", model);
        }
        public async Task<IActionResult> Create(VillaNumberDTO model)
        {
            var response = await _service.CreateAsync<APIResponse<VillaNumberDTO>>(model);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Index", "VillaNumber");
            }
            return View(model);
        }
        public async Task<IActionResult> Details(string Id)
        {
            VillaNumberDTO villas = new();
            var response = await _service.GetAsync<APIResponse<VillaNumberDTO>>(Id);
            if (response != null && response.IsSuccess)
            {
                villas = response.Result;
            }
            return View(villas);
        }
        public async Task<IActionResult> Delete(string Id)
        {
            VillaNumberDTO villas = new();
            var response = await _service.DeleteAsync<APIResponse<VillaNumberDTO>>(Id);
            if (response != null && response.IsSuccess)
            {
                villas = response.Result;
                return RedirectToAction("Index", "VillaNumber");
            }
            return View(villas);
        }
        public async Task<IActionResult> ViewUpdate(VillaNumberDTO model)
        {
            var response = await _service.GetAsync<APIResponse<VillaNumberDTO>>(model.Id);
            if (response != null && response.IsSuccess)
            {
                model = response.Result;
            }
            return View("Update", model);
        }
        public async Task<IActionResult> Update(VillaNumberDTO model)
        {
            var response = await _service.UpdateAsync<APIResponse<VillaNumberDTO>>(model);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Index", "VillaNumber");
            }
            return View(model);
        }
    }
}
