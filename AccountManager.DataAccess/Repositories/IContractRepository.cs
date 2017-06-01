using AccountManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AccountManager.DataAccess.Repositories
{
    public interface IContractRepository
    {
        IEnumerable<Contract> GetContractsForCompany(int companyId);
        Contract GetContractForCompany(int companyId, int contractId);
    }

    public class ContractRepository : IContractRepository
    {
        private readonly AccountsDbContext _dbContext;

        public ContractRepository(AccountsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Contract> GetContractsForCompany(int companyId)
        {
            return _dbContext.Contracts.Where(x => x.CompanyId == companyId);
        }
        public Contract GetContractForCompany(int companyId, int contractId)
        {
            return _dbContext.Contracts.FirstOrDefault(x => x.CompanyId == companyId && x.Id == contractId);
        }
    }
}
