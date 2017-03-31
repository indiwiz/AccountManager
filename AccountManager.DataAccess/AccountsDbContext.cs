using AccountManager.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AccountManager.DataAccess
{
    public class AccountsDbContext : IdentityDbContext<User>
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Company> Companies { get; set; }
    }
}
