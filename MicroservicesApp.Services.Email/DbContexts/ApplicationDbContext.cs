using MicroservicesApp.Services.Email.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesApp.Services.Email.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<EmailLog> EmailLogs { get; set; }
    }
}
