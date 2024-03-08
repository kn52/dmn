using MagicVilla_Uitility;
using MagicVilla_Web.HttpExtensions;
using MagicVilla_Web.Models.DTO;
using MagicVillaServiceJ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly MagicVillaServiceJClient _service;
        private readonly HttpManager httpManager;

        public VillaNumberController(MagicVillaServiceJClient service, HttpManager httpManager)
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
            List<VillaNumberDTO> villas = new();
            var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
            _service.AddToken(token);

            var response = await _service.GetVillaNumbersAsync().ConfigureAwait(false);
            if (response != null && response.Result != null && response.IsSuccess)
            {
                villas = response.Result.ToList();
            }
            return View(villas);
        }
        public async Task<IActionResult> ViewCreate(VillaNumberDTO model)
        {
            var createModel = new Models.DTO.VillaNumberModifyDTO();
            var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
            _service.AddToken(token);

            var response = await _service.GetVillaListAsync().ConfigureAwait(false);
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
                var token1 = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
                _service.AddToken(token1);

                var response = await _service.CreateVillaNumberAsync(createModel).ConfigureAwait(false);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "VillaNumber created successfully.";
                    return Redirect("/VillaNumber");
                }
            }
            var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
            _service.AddToken(token);

            var response2 = await _service.GetVillaListAsync().ConfigureAwait(false);
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
            var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
            _service.AddToken(token);

            var response = await _service.GetVillaNumberByIdAsync(Id).ConfigureAwait(false);
            if (response != null && response.IsSuccess)
            {
                villas = response.Result;
            }
            return View(villas);
        }
        public async Task<IActionResult> Delete(string Id)
        {
            VillaNumberDTO villas = new();
            var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
            _service.AddToken(token);

            var response = await _service.DeleteVillaNumberAsync(Id).ConfigureAwait(false);
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
            var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
            _service.AddToken(token);

            var response = await _service.GetVillaNumberByIdAsync(model.Id).ConfigureAwait(false);
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
                var response2 = await _service.GetVillaListAsync().ConfigureAwait(false);
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
                var token1 = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
                _service.AddToken(token1);

                var response = await _service.UpdateVillaNumberAsync(updateModel.Id, updateModel).ConfigureAwait(false);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "VillaNumber updated successfully.";
                    return Redirect("/VillaNumber");
                }
            }
            var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
            _service.AddToken(token);

            var response2 = await _service.GetVillaListAsync().ConfigureAwait(false);
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
