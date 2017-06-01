using AccountManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AccountManager.DataAccess.Repositories
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAll();

        Task Create(Company company);

        Company GetByIdentifier(string identifier);
    }

    public class CompanyRepository : ICompanyRepository
    {
        private readonly AccountsDbContext _dbContext;
        public CompanyRepository(AccountsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Company> GetAll()
        {
            return _dbContext.Companies;
        }

        public async Task Create(Company company)
        {
            _dbContext.Companies.Add(company);
            await _dbContext.SaveChangesAsync();
        }

        public Company GetByIdentifier(string identifier)
        {
            return _dbContext.Companies.FirstOrDefault(c => c.Identifier == identifier);
        }
    }
}
