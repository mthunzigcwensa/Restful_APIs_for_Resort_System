using RestfulAPIs.Data;
using RestfulAPIs.Models;
using RestfulAPIs.Repositories.IRepostiories;

namespace RestfulAPIs.Repositories
{
    public class ResortRepository : Repository<Resort>, IResortRepository
    {
        private readonly DataBaseContext _db;
        public ResortRepository(DataBaseContext db) : base(db)
        {
            _db = db;
        }


        public async Task<Resort> UpdateAsync(Resort entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Resorts.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
