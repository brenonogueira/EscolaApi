using Microsoft.EntityFrameworkCore;
using Sapiens.Core.Repositories;
using School.Core.Contexts;

namespace School.Core.Repositories
{
    public interface ISchoolRepository : IEntityRepository<Entities.SchoolEntity>
    {

    }

    public class SchoolRepository : ISchoolRepository
    {
        private readonly DataContext db;

        public SchoolRepository(DataContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Entities.SchoolEntity>> GetAllAsync()
        {
            return await db.Schools.ToListAsync();
        }

        public async Task<Entities.SchoolEntity?> GetByIdAsync(long id)
        {
            return await db.Schools.FindAsync(id);
        }

        public async Task AddAsync(Entities.SchoolEntity school)
        {
           await db.Schools.AddAsync(school);
        }

        public void Update(Entities.SchoolEntity school)
        {
            db.Entry(school).State = EntityState.Modified;
        }

        public async Task<int> SaveAsync()
        {
            return await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var school = await db.Schools.FindAsync(id);
            if (school != null) 
                db.Schools.Remove(school);
        }

        public async Task<bool> Exists(long id)
        {
            return await db.Schools.AnyAsync(c => c.Id == id);
        }
    }
}
