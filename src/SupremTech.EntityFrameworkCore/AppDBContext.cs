using Microsoft.EntityFrameworkCore;
using SupremTech.Domain;


namespace SupremTech.EntityFrameworkCore
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Customers> CustomersSet { get; set; }
        public DbSet<Product> ProductsSet { get; set; }
        public DbSet<Category> CategoriesSet { get; set; }
        public DbSet<Order> OrdersSet { get; set; }
        public DbSet<OrderDetail> OrderDetailsSet { get; set; }

    }
}