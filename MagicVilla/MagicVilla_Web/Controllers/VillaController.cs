using AutoMapper;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Models.Model;
using MagicVilla_Web.Models.Responses;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

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

            var response = await _service.GetAllAsync<ApiResponse<List<VillaDTO>>>();
            if (response != null && response.Result != null && response.IsSuccess)
            {
                villas = JsonSerializer.Deserialize<List<VillaDTO>>(Convert.ToString(response.Result));
            }
            return View(villas);
        }
        public async Task<IActionResult> Create(VillaDTO model)
        {
            var response = await _service.CreateAsync<ApiResponse<VillaDTO>>(model);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("./Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Details()
        {
            List<VillaDTO> villas = new();
            ApiResponse<IEntity> response = await _service.GetAllAsync<ApiResponse<IEntity>>();
            if (response != null && response.IsSuccess)
            {
                villas = JsonSerializer.Deserialize<List<VillaDTO>>(Convert.ToString(response.Result));
            }
            return View(villas);
        }
        public async Task<IActionResult> Delete()
        {
            List<VillaDTO> villas = new();

            return View(villas);
        }
        public async Task<IActionResult> Update(VillaDTO model)
        {
            ApiResponse<IEntity> response = await _service.CreateAsync<ApiResponse<IEntity>>(model);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("./Index");
            }
            return View(model);
        }
    }
}
