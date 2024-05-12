using presentation.Models;
using presentation.Models.Dto;
using presentation.Services.IServices;
using Utility;

namespace presentation.Services
{
    public class ResortNumberService : BaseService, IResortNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string ResortUrl;

        public ResortNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            ResortUrl = configuration.GetValue<string>("ServiceUrls:ResortAPI");

        }

        public Task<T> CreateAsync<T>(ResortNumberCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortNumberAPI",
                
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortNumberAPI/" + id,
                
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortNumberAPI",
                
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortNumberAPI/" + id,
                
            });
        }

        public Task<T> UpdateAsync<T>(ResortNumberUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortNumberAPI/" + dto.ResortNo,
                
            });
        }
    }
}
