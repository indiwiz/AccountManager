using System.Threading.Tasks;

namespace AccountManager.DataAccess.Repositories
{
    public interface IBaseRepository
    {
        Task<bool> SaveChangesAsync();
    }

    public class BaseRepository : IBaseRepository
    {
        protected AccountsDbContext DbContext { get; }

        public BaseRepository(AccountsDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<bool> SaveChangesAsync()
        {
            var i = await DbContext.SaveChangesAsync();
            return i >= 0;
        }
    }
}
