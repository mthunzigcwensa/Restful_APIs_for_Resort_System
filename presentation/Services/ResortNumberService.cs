using presentation.Models;
using presentation.Models.Dto;
using presentation.Services.IServices;
using Utility;

namespace presentation.Services
{
    public class ResortNumberService :  IResortNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IBaseService _baseService;
        private string ResortUrl;

        public ResortNumberService(IHttpClientFactory clientFactory, IConfiguration configuration, IBaseService baseService)
        {
            _clientFactory = clientFactory;
            ResortUrl = configuration.GetValue<string>("ServiceUrls:ResortAPI");
            _baseService = baseService;
        }

        public async Task<T> CreateAsync<T>(ResortNumberCreateDTO dto)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortNumberAPI",
                
            });
        }

        public async Task<T> DeleteAsync<T>(int id)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortNumberAPI/" + id,
                
            });
        }

        public async Task<T> GetAllAsync<T>()
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortNumberAPI",
                
            });
        }

        public async Task<T> GetAsync<T>(int id)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortNumberAPI/" + id,
                
            });
        }

        public async Task<T> UpdateAsync<T>(ResortNumberUpdateDTO dto)
        {
            return await _baseService.SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortNumberAPI/" + dto.ResortNo,
                
            });
        }
    }
}
