using Ecommerce.Discount.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Discount.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }



        public DbSet<Coupon> Coupons { get; set; }
    }

}

