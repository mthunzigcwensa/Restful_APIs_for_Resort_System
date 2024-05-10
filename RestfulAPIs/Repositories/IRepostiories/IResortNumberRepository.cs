using RestfulAPIs.Models;

namespace RestfulAPIs.Repositories.IRepostiories
{
    public interface IResortNumberRepository : IRepository<ResortNumber>
    {

        Task<ResortNumber> UpdateAsync(ResortNumber entity);

    }
}
