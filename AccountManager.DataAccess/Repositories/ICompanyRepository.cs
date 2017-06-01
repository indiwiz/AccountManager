using AccountManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace AccountManager.DataAccess.Repositories
{
    public interface ICompanyRepository : IBaseRepository
    {
        IEnumerable<Company> GetAll();

        void Create(Company company);

        Company GetByIdentifier(string identifier);
    }

    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(AccountsDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<Company> GetAll()
        {
            return DbContext.Companies;
        }

        public void Create(Company company)
        {
            DbContext.Companies.Add(company);
        }

        public Company GetByIdentifier(string identifier)
        {
            return DbContext.Companies.FirstOrDefault(c => c.Identifier == identifier);
        }
    }
}
