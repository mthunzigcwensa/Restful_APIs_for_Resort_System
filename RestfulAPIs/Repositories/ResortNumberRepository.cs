using RestfulAPIs.Data;
using RestfulAPIs.Models;
using RestfulAPIs.Repositories.IRepostiories;

namespace RestfulAPIs.Repositories
{
    public class ResortNumberRepository : Repository<ResortNumber>, IResortNumberRepository
    {
        private readonly DataBaseContext _db;
        public ResortNumberRepository(DataBaseContext db) : base(db)
        {
            _db = db;
        }


        public async Task<ResortNumber> UpdateAsync(ResortNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.ResortNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
