using ECommerce.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Order.Persistence.Contexts // Değiştirildi
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
