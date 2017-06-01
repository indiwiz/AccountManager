using AccountManager.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AccountManager.DataAccess.Repositories
{
    public interface IContractRepository : IBaseRepository
    {
        IEnumerable<Contract> GetContractsForCompany(int companyId);
        Contract GetContractForCompany(int companyId, int contractId);
        void CreateContract(Contract contract);
    }

    public class ContractRepository : BaseRepository, IContractRepository
    {
        public ContractRepository(AccountsDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<Contract> GetContractsForCompany(int companyId)
        {
            return DbContext.Contracts.Where(x => x.CompanyId == companyId);
        }
        public Contract GetContractForCompany(int companyId, int contractId)
        {
            return DbContext.Contracts.FirstOrDefault(x => x.CompanyId == companyId && x.Id == contractId);
        }

        public void CreateContract(Contract contract)
        {
            DbContext.Contracts.Add(contract);
        }
    }
}
