using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Assignment_shopping_shirt.Models
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext()
        {

        }
        public ShopDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Color> Colors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=IAMTHAIS\SQLEXPRESS01;Initial Catalog=Shopping_shirt_v2;Integrated Security=True;User ID=thaitdph26029;Password=tranduythai2003");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
