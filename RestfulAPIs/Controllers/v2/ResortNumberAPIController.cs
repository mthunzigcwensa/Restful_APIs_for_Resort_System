using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestfulAPIs.Models;
using RestfulAPIs.Models.DTOs;
using RestfulAPIs.Repositories.IRepostiories;
using System.Net;

namespace RestfulAPIs.Controllers.v2
{
    [Route("api/v{version:apiVersion}/ResortNumberAPI")]
    [ApiController]
    [ApiVersion("2.0")] 

    public class ResortNumberAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IResortNumberRepository _dbResortNumber;
        private readonly IResortRepository _dbResort;
        private readonly IMapper _mapper;
        public ResortNumberAPIController(IResortNumberRepository dbResortNumber, IMapper mapper,
            IResortRepository dbResort)
        {
            _dbResortNumber = dbResortNumber;
            _mapper = mapper;
            _response = new();
            _dbResort = dbResort;
        }


        [HttpGet("GetString")]
        public IEnumerable<string> Get() 
        {
            return new string[] { "mthunzi", "gcwensa" };
        }

        [HttpGet]
        //[MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {

                IEnumerable<ResortNumber> villaNumberList = await _dbResortNumber.GetAllAsync(includeProperties: "Resort");
                _response.Result = _mapper.Map<List<ResortNumberDTO>>(villaNumberList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;

        }


        [HttpGet("{id:int}", Name = "GetResortNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetResortNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villaNumber = await _dbResortNumber.GetAsync(u => u.ResortNo == id);
                if (villaNumber == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<ResortNumberDTO>(villaNumber);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateResortNumber([FromBody] ResortNumberCreateDTO createDTO)
        {
            try
            {

                if (await _dbResortNumber.GetAsync(u => u.ResortNo == createDTO.ResortNo) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Resort Number already Exists!");
                    return BadRequest(ModelState);
                }
                if (await _dbResort.GetAsync(u => u.Id == createDTO.ResortID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Resort ID is Invalid!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                ResortNumber resortNumber = _mapper.Map<ResortNumber>(createDTO);

               
                await _dbResortNumber.CreateAsync(resortNumber);
                _response.Result = _mapper.Map<ResortNumberDTO>(resortNumber);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetResort", new { id = resortNumber.ResortNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteResortNumber")]
        public async Task<ActionResult<APIResponse>> DeleteResortNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var resortNumber = await _dbResortNumber.GetAsync(u => u.ResortNo == id);
                if (resortNumber == null)
                {
                    return NotFound();
                }
                await _dbResortNumber.RemoveAsync(resortNumber);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [Authorize(Roles = "admin")]
        [HttpPut("{id:int}", Name = "UpdateResortNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateResortNumber(int id, [FromBody] ResortNumberUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.ResortNo)
                {
                    return BadRequest();
                }
                if (await _dbResort.GetAsync(u => u.Id == updateDTO.ResortID) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Resort ID is Invalid!");
                    return BadRequest(ModelState);
                }
                ResortNumber model = _mapper.Map<ResortNumber>(updateDTO);

                await _dbResortNumber.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


    }
}
