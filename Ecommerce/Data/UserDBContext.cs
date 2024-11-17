using Ecommerce.Data.config;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    public class UserDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Address> Addresses { get; set; }


        public UserDBContext(DbContextOptions<UserDBContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new userConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new CartConfig());
            modelBuilder.ApplyConfiguration(new CatogoryConfig());
            modelBuilder.ApplyConfiguration(new cartItemConfig());
            modelBuilder.ApplyConfiguration(new WishListConfig());  
            modelBuilder.ApplyConfiguration(new AddressConfig());  

        }
    }
}
