using AutoMapper;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Models.Responses;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _service;
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;
        public VillaNumberController(IVillaNumberService service, IVillaService villaService, IMapper mapper)
        {
            _service = service;
            _villaService = villaService;
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
            var createModel = new VillaNumberModifyDTO();
            var response = await _villaService.GetAllAsync<APIResponse<List<VillaDTO>>>();
            if (response != null && response.IsSuccess)
            {
                var villas = response.Result;
                createModel.VillaList = villas.Select(villa => new SelectListItem
                {
                    Text = villa.Name,
                    Value = villa.Id
                }).ToList();
            }
            return View("Create", createModel);
        }
        public async Task<IActionResult> Create(VillaNumberModifyDTO model)
        {
            if (!string.IsNullOrEmpty(model.VillaId) || !string.IsNullOrEmpty(model.VillaNo))
            {
                var createModel = new VillaNumberDTO()
                {
                    VillaNo = model.VillaNo,
                    VillaId = model.VillaId,
                    SpecialDetails = model.SpecialDetails,
                    Villa = null,
                    CreatedDateTime = string.Empty,
                    UpdatedDateTime = string.Empty
                };
                var response = await _service.CreateAsync<APIResponse<VillaNumberDTO>>(createModel);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "VillaNumber created successfully.";
                    return Redirect("/VillaNumber");
                }
            }
            var response2 = await _villaService.GetAllAsync<APIResponse<List<VillaDTO>>>();
            if (response2 != null && response2.IsSuccess)
            {
                var villas = response2.Result;
                model.VillaList = villas.Select(villa => new SelectListItem
                {
                    Text = villa.Name,
                    Value = villa.Id
                }).ToList();
            }
            TempData["error"] = "Error encountered.";
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
                TempData["success"] = "VillaNumber deleted successfully.";
                villas = response.Result;
                return Redirect("/VillaNumber");
            }
            TempData["error"] = "Error encountered.";
            return View(villas);
        }
        public async Task<IActionResult> ViewUpdate(VillaNumberDTO model)
        {
            VillaNumberModifyDTO updateModel = null;

            var response = await _service.GetAsync<APIResponse<VillaNumberDTO>>(model.Id);
            if (response != null && response.IsSuccess)
            {
                model = response.Result;
                updateModel = new VillaNumberModifyDTO()
                {
                    Id = model.Id,
                    VillaNo = model.VillaNo,
                    VillaId = model.VillaId,
                    SpecialDetails = model.SpecialDetails,
                };
                var response2 = await _villaService.GetAllAsync<APIResponse<List<VillaDTO>>>();
                if (response2 != null && response2.IsSuccess)
                {
                    var villas = response2.Result;
                    updateModel.VillaList = villas.Select(villa => new SelectListItem
                    {
                        Text = villa.Name,
                        Value = villa.Id,
                        Selected = villa.Id == model.VillaId
                    }).ToList();
                }
                return View("Update", updateModel);
            }
            updateModel = new VillaNumberModifyDTO();
            return View("Update", updateModel);
        }
        public async Task<IActionResult> Update(VillaNumberModifyDTO model)
        {
            if (!string.IsNullOrEmpty(model.VillaNo) && !string.IsNullOrEmpty(model.VillaId))
            {
                var updateModel = new VillaNumberDTO()
                {
                    Id = model.Id,
                    VillaNo = model.VillaNo,
                    VillaId = model.VillaId,
                    SpecialDetails = model.SpecialDetails,
                    Villa = null,
                    CreatedDateTime = string.Empty,
                    UpdatedDateTime = string.Empty
                };
                var response = await _service.UpdateAsync<APIResponse<VillaNumberDTO>>(updateModel);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "VillaNumber updated successfully.";
                    return Redirect("/VillaNumber");
                }
            }
            var response2 = await _villaService.GetAllAsync<APIResponse<List<VillaDTO>>>();
            if (response2 != null && response2.IsSuccess)
            {
                var villas = response2.Result;
                model.VillaList = villas.Select(villa => new SelectListItem
                {
                    Text = villa.Name,
                    Value = villa.Id,
                    Selected = villa.Id == model.VillaId
                }).ToList();
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
    }
}
