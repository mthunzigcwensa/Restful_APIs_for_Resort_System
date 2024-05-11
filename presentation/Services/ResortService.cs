using presentation.Models;
using presentation.Models.Dto;
using presentation.Services.IServices;
using Utility;

namespace presentation.Services
{
    public class ResortService : BaseService, IResortService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string ResortUrl;

        public ResortService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            ResortUrl = configuration.GetValue<string>("ServiceUrls:ResortAPI");

        }

        public Task<T> CreateAsync<T>(ResortCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortAPI",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortAPI/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortAPI/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(ResortUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = ResortUrl + $"/api/{SD.CurrentAPIVersion}/resortAPI/" + dto.Id,
                Token = token
            });
        }
    }
}
