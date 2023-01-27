using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options) { Database.EnsureCreated(); }

        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryEntity>(entity =>
            {
                entity.HasNoKey()
                    .HasIndex(x => x.CategoryId)
                    .IsUnique();
            });

            base.OnModelCreating(builder);
        }
    }
}
