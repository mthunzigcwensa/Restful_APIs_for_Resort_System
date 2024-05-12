using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using presentation.Models;
using presentation.Models.Dto;
using presentation.Services;
using presentation.Services.IServices;
using Utility;

namespace presentation.Controllers
{
    public class ResortController : Controller
    {
        private readonly IResortService _ResortService;
        private readonly IMapper _mapper;
        public ResortController(IResortService ResortService, IMapper mapper)
        {
            _ResortService = ResortService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexResort()
        {
            List<ResortDTO> list = new();

            var response = await _ResortService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ResortDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateResort()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateResort(ResortCreateDTO model)
        {
            if (ModelState.IsValid)
            {

                var response = await _ResortService.CreateAsync<APIResponse>(model) ;
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Resort created successfully";
                    return RedirectToAction(nameof(IndexResort));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateResort(int ResortId)
        {
            var response = await _ResortService.GetAsync<APIResponse>(ResortId) ;
            if (response != null && response.IsSuccess)
            {

                ResortDTO model = JsonConvert.DeserializeObject<ResortDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<ResortUpdateDTO>(model));
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateResort(ResortUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Resort updated successfully";
                var response = await _ResortService.UpdateAsync<APIResponse>(model) ;
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexResort));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteResort(int ResortId)
        {
            var response = await _ResortService.GetAsync<APIResponse>(ResortId) ;
            if (response != null && response.IsSuccess)
            {
                ResortDTO model = JsonConvert.DeserializeObject<ResortDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteResort(ResortDTO model)
        {

            var response = await _ResortService.DeleteAsync<APIResponse>(model.Id);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Resort deleted successfully";
                return RedirectToAction(nameof(IndexResort));
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }

    }
}
