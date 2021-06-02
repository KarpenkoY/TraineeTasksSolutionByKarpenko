using Microsoft.EntityFrameworkCore;

namespace MyShop
{
    class AppContext : DbContext
    {
        public DbSet<Product>   Products { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Supplier>  Suppliers { get; set; }

        public AppContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=myshop;Trusted_Connection=Ture;");

        }
    }
}
