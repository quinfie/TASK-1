
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Task1.Models;

namespace Task1.Data
{
    public class MyDbContext : IdentityDbContext<IdentityUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
        }
    }
}


