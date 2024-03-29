﻿using MagicVilla_Uitility;
using MagicVilla_Web.HttpExtensions;
using MagicVilla_Web.Models.DTO;
using MagicVillaServiceJ;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly MagicVillaServiceJClient _service;
        private readonly HttpManager httpManager;

        public VillaController(MagicVillaServiceJClient service, HttpManager httpManager)
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
        public async Task<IActionResult> ViewCreate(VillaDTO model)
        {
            var createModel = new VillaModifyDTO();
            return View("Create", createModel);
        }
        public async Task<IActionResult> Create(VillaModifyDTO model)
        {
            var craeteModel = new VillaDTO() 
            {
                Name = model.Name,
                Details = model.Details,
                Rate = model.Rate,
                Occupancy = model.Occupancy,
                Sqft = model.Sqft,
                Amenity = model.Amenity,
                ImageUrl = model.ImageUrl,
                CreatedDateTime = string.Empty,
                UpdatedDateTime = string.Empty
            };
            var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
            _service.AddToken(token);

            var response = await _service.CreateVillaAsync(craeteModel).ConfigureAwait(false);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Villa created successfully.";
                return Redirect("/Villa");
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        public async Task<IActionResult> Details(string Id)
        {
            VillaDTO villas = new();
            var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
            _service.AddToken(token);
            
            var response = await _service.GetVillaByIdAsync(Id).ConfigureAwait(false);
            if (response != null && response.IsSuccess)
            {
                villas = response.Result;
            }
            return View(villas);
        }
        public async Task<IActionResult> Delete(string Id)
        {
            VillaDTO villas = new();
            var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
            _service.AddToken(token);

            var response = await _service.DeleteVillaAsync(Id).ConfigureAwait(false);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Villa deleted successfully.";
                villas = response.Result;
                return Redirect("/Villa");
            }
            TempData["error"] = "Error encountered.";
            return View(villas);
        }
        public async Task<IActionResult> ViewUpdate(VillaDTO model)
        {
            VillaModifyDTO updateModel = null;
            var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
            _service.AddToken(token);

            var response = await _service.GetVillaByIdAsync(model.Id).ConfigureAwait(false);
            if (response != null && response.IsSuccess)
            {
                model = response.Result;
                updateModel = new VillaModifyDTO()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Details = model.Details,
                    Rate = model.Rate,
                    Occupancy = model.Occupancy,
                    Sqft = model.Sqft,
                    Amenity = model.Amenity,
                    ImageUrl = model.ImageUrl
                };
                return View("Update", updateModel);
            }
            updateModel = new VillaModifyDTO();
            return View("Update", updateModel);
        }
        public async Task<IActionResult> Update(VillaModifyDTO model)
        {
            var updateModel = new VillaDTO()
            {
                Id = model.Id,
                Name = model.Name,
                Details = model.Details,
                Rate = model.Rate,
                Occupancy = model.Occupancy,
                Sqft = model.Sqft,
                Amenity = model.Amenity,
                ImageUrl = model.ImageUrl,
                CreatedDateTime = string.Empty,
                UpdatedDateTime = string.Empty
            };
            var token = await httpManager.GetSessionDetailsByKey(Constants.JWT).ConfigureAwait(false);
            _service.AddToken(token);

            var response = await _service.UpdateVillaAsync(updateModel.Id, updateModel).ConfigureAwait(false);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Villa updated successfully.";
                return Redirect("/Villa");
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
    }
}
