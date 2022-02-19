using MicroservicesApp.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesApp.Services.CouponAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Coupon> Coupons { get; set; }
    }
}
