using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;

namespace DataAccess
{
    public class AppContext : DbContext
    {
        public DbSet<OrderModel> Orders { get; set; }

        public DbSet<ProductModel> Products { get; set; }

        public AppContext() => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderModel>()
                .Property(b => b.Id)
                .IsRequired();

            modelBuilder.Entity<ProductModel>()
                .Property(b => b.Id)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrderDb;Integrated Security=True");
        }
    }
}
