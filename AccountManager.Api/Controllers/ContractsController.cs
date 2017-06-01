using AccountManager.Api.Models;
using AccountManager.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static AutoMapper.Mapper;

namespace AccountManager.Api.Controllers
{
    [Route("api/companies/{identifier}/contracts")]
    public class ContractsController : Controller
    {
        private readonly IContractRepository _contractRepository;
        private readonly ICompanyRepository _companyRepository;

        public ContractsController(IContractRepository contractRepository, ICompanyRepository companyRepository)
        {
            _contractRepository = contractRepository;
            _companyRepository = companyRepository;
        }

        public IActionResult GetContractsForCompany(string identifier)
        {
            var company = _companyRepository.GetByIdentifier(identifier);
            if (company == null) return NotFound();
            var contracts = _contractRepository.GetContractsForCompany(company.Id);
            return Ok(Map<IEnumerable<ContractDto>>(contracts));
        }

        [HttpGet("{id}")]
        public IActionResult GetContractForCompany(string identifier, int id)
        {
            var company = _companyRepository.GetByIdentifier(identifier);
            if (company == null) return NotFound();
            var contract = _contractRepository.GetContractForCompany(company.Id, id);
            if (contract == null) return NotFound();
            return Ok(Map<ContractDto>(contract));
        }
    }
}
