using Microsoft.EntityFrameworkCore;
using Sapiens.Core.Repositories;
using School.Core.Contexts;
using School.Core.Entities;

namespace School.Core.Repositories
{
    public interface ICityRepository : IEntityRepository<City>
    {

    }

    public class CityRepository : ICityRepository
    {
        private readonly DataContext db;

        public CityRepository(DataContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await db.Cities.ToListAsync();
        }

        public async Task<City?> GetByIdAsync(long id)
        {
            return await db.Cities.FindAsync(id);
        }

        public async Task AddAsync(City city)
        {
           await db.Cities.AddAsync(city);
        }

        public void Update(City city)
        {
            db.Entry(city).State = EntityState.Modified;
        }

        public async Task<int> SaveAsync()
        {
            return await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var city = await db.Cities.FindAsync(id);
            if (city != null) 
                db.Cities.Remove(city);
        }

        public async Task<bool> Exists(long id)
        {
            return await db.Cities.AnyAsync(c => c.Id == id);
        }

       

       

       

       
    }
}
