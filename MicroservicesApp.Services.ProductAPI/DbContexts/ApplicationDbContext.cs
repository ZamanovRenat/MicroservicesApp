using MicroservicesApp.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesApp.Services.ProductAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
