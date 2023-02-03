using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(entity =>
            {
                entity.Property(x => x.Picture)
                    .IsRequired(false);
            });

            base.OnModelCreating(builder);
        }
    }
}