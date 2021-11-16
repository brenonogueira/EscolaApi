using Microsoft.EntityFrameworkCore;

namespace School.Core.Contexts
{
    public class DataContext: DbContext
    {
#pragma warning disable CS8618
        public DbSet<Entities.City> Cities { get; set; }
        public DbSet<Entities.SchoolEntity> Schools { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
#pragma warning restore CS8618

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        } 
    }
}
