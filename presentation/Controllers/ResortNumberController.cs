using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using presentation.Models;
using presentation.Models.Dto;
using presentation.Models.VM;
using presentation.Services;
using presentation.Services.IServices;
using Utility;

namespace presentation.Controllers
{
    public class ResortNumberController : Controller
    {
        private readonly IResortNumberService _ResortNumberService;
        private readonly IResortService _ResortService;
        private readonly IMapper _mapper;
        public ResortNumberController(IResortNumberService ResortNumberService, IMapper mapper, IResortService ResortService)
        {
            _ResortNumberService = ResortNumberService;
            _mapper = mapper;
            _ResortService = ResortService;
        }

        public async Task<IActionResult> IndexResortNumber()
        {
            List<ResortNumberDTO> list = new();

            var response = await _ResortNumberService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ResortNumberDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateResortNumber()
        {
            ResortNumberCreateVM ResortNumberVM = new();
            var response = await _ResortService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                ResortNumberVM.ResortsList = JsonConvert.DeserializeObject<List<ResortDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }); ;
            }
            return View(ResortNumberVM);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateResortNumber(ResortNumberCreateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _ResortNumberService.CreateAsync<APIResponse>(model.ResortNumber) ;
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexResortNumber));
                }
                else
                {
                    TempData["error"] = (response.ErrorMessages != null && response.ErrorMessages.Count > 0) ?
                        response.ErrorMessages[0] : "Error Encountered";
                }
            }

            var resp = await _ResortService.GetAllAsync<APIResponse>();
            if (resp != null && resp.IsSuccess)
            {
                model.ResortsList = JsonConvert.DeserializeObject<List<ResortDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }); ;
            }
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateResortNumber(int ResortNo)
        {
            ResortNumberUpdateVM ResortNumberVM = new();
            var response = await _ResortNumberService.GetAsync<APIResponse>(ResortNo) ;
            if (response != null && response.IsSuccess)
            {
                ResortNumberDTO model = JsonConvert.DeserializeObject<ResortNumberDTO>(Convert.ToString(response.Result));
                ResortNumberVM.ResortNumber = _mapper.Map<ResortNumberUpdateDTO>(model);
            }

            response = await _ResortService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                ResortNumberVM.ResortsList = JsonConvert.DeserializeObject<List<ResortDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
                return View(ResortNumberVM);
            }
            else
            {
                TempData["error"] = (response.ErrorMessages != null && response.ErrorMessages.Count > 0) ?
                    response.ErrorMessages[0] : "Error Encountered";
            }


            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateResortNumber(ResortNumberUpdateVM model)
        {
            if (ModelState.IsValid)
            {

                var response = await _ResortNumberService.UpdateAsync<APIResponse>(model.ResortNumber) ;
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexResortNumber));
                }
                else
                {
                    TempData["error"] = (response.ErrorMessages != null && response.ErrorMessages.Count > 0) ?
                        response.ErrorMessages[0] : "Error Encountered";
                }
            }

            var resp = await _ResortService.GetAllAsync<APIResponse>();
            if (resp != null && resp.IsSuccess)
            {
                model.ResortsList = JsonConvert.DeserializeObject<List<ResortDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    }); ;
            }
            return View(model);
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteResortNumber(int ResortNo)
        {
            ResortNumberDeleteVM ResortNumberVM = new();
            var response = await _ResortNumberService.GetAsync<APIResponse>(ResortNo) ;
            if (response != null && response.IsSuccess)
            {
                ResortNumberDTO model = JsonConvert.DeserializeObject<ResortNumberDTO>(Convert.ToString(response.Result));
                ResortNumberVM.ResortNumber = model;
            }

            response = await _ResortService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                ResortNumberVM.ResortsList = JsonConvert.DeserializeObject<List<ResortDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
                return View(ResortNumberVM);
            }


            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(ResortNumberDeleteVM model)
        {

            var response = await _ResortNumberService.DeleteAsync<APIResponse>(model.ResortNumber.ResortNo) ;
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexResortNumber));
            }
            else
            {
                TempData["error"] = (response.ErrorMessages != null && response.ErrorMessages.Count > 0) ?
                    response.ErrorMessages[0] : "Error Encountered";
            }

            return View(model);
        }



    }
}
