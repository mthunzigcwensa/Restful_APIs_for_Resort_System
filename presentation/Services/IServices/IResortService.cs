using presentation.Models.Dto;

namespace presentation.Services.IServices
{
    public interface IResortService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(ResortCreateDTO dto);
        Task<T> UpdateAsync<T>(ResortUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
