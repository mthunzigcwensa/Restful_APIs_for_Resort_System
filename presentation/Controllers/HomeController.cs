using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using presentation.Models;
using presentation.Models.Dto;
using presentation.Services.IServices;
using System.Diagnostics;
using Utility;

namespace presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IResortService _ResortService;
        private readonly IMapper _mapper;
        public HomeController(IResortService ResortService, IMapper mapper)
        {
            _ResortService = ResortService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<ResortDTO> list = new();

            var response = await _ResortService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ResortDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

    }
}
