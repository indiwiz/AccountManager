using AccountManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AccountManager.DataAccess.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAll();

        Task Create(Company company);

        Company GetByIdentifier(string identifier);
    }

    public class CompanyService : ICompanyService
    {
        private readonly AccountsDbContext _dbContext;
        public CompanyService(AccountsDbContext dbContext)
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
