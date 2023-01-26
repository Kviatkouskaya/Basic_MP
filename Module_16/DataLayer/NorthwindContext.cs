using Microsoft.EntityFrameworkCore;
using TransitLayer;

namespace DataAccess
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options) { Database.EnsureCreated(); }

        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryModel>(entity =>
            {
                entity.HasIndex(x => x.Id).
                    IsUnique();
            });

            base.OnModelCreating(builder);
        }
    }
}
