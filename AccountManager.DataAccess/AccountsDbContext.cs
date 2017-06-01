using AccountManager.DataAccess.Configurations;
using AccountManager.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.DataAccess
{
    public class AccountsDbContext : IdentityDbContext<User>
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
            : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddConfiguration(new CompanyConfiguration());
            modelBuilder.AddConfiguration(new ContractConfiguration());
        }
    }
}
