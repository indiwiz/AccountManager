using AccountManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.DataAccess
{
    public class AccountsDbContext : DbContext
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
            :base(options)
        {
            
        }
        public DbSet<Company> Companies { get; set; }
    }
}
