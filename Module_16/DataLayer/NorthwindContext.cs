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
        public DbSet<SupplierEntity> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CategoryEntity>(entity =>
            {
                entity.HasNoKey()
                    .HasIndex(x => x.CategoryID)
                    .IsUnique();
            });

            builder.Entity<ProductEntity>(entity =>
            {
                entity.HasNoKey()
                    .HasIndex(x => x.ProductID)
                    .IsUnique();
            });

            builder.Entity<SupplierEntity>(entity =>
            {
                entity.HasNoKey()
                    .HasIndex(x => x.SupplierID)
                    .IsUnique();

                entity.Property(x => x.ContactName)
                    .IsRequired(false);

                entity.Property(x => x.ContactTitle)
                    .IsRequired(false);

                entity.Property(x => x.Address)
                    .IsRequired(false);

                entity.Property(x => x.City)
                    .IsRequired(false);

                entity.Property(x => x.Region)
                    .IsRequired(false);

                entity.Property(x => x.PostalCode)
                    .IsRequired(false);

                entity.Property(x => x.Country)
                    .IsRequired(false);

                entity.Property(x => x.Phone)
                    .IsRequired(false);

                entity.Property(x => x.Fax)
                    .IsRequired(false);

                entity.Property(x => x.HomePage)
                    .IsRequired(false);

            });

            base.OnModelCreating(builder);
        }
    }
}
