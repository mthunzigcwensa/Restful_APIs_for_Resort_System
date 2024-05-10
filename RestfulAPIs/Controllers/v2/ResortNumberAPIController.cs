using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestfulAPIs.Models;
using RestfulAPIs.Repositories.IRepostiories;

namespace RestfulAPIs.Controllers.v2
{
    [Route("api/v{version:apiVersion}/ResortNumberAPI")]
    [ApiController]
    [ApiVersion("2.0")]
    public class VillaNumberAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IResortNumberRepository _dbResortNumber;
        private readonly IResortRepository _dbVilla;
        private readonly IMapper _mapper;
        public VillaNumberAPIController(IResortNumberRepository dbResortNumber, IMapper mapper,
            IResortRepository dbResort)
        {
            _dbResortNumber = dbResortNumber;
            _mapper = mapper;
            _response = new();
            _dbVilla = dbResort;
        }


        //[MapToApiVersion("2.0")]
        [HttpGet("GetString")]
        public IEnumerable<string> Get()
        {
            return new string[] { "mthunzi", "gcwensa" };
        }


    }
}
