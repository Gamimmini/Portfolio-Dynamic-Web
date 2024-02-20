using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<AdminAccount> AdminAccounts { get; set; }
    }
}
