using RestfulAPIs.Models;

namespace RestfulAPIs.Repositories.IRepostiories
{
    public interface IResortRepository : IRepository<Resort>
    {

        Task<Resort> UpdateAsync(Resort entity);

    }
}
