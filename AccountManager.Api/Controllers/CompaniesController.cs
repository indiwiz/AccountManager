using AccountManager.Api.Models;
using AccountManager.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static AutoMapper.Mapper;

namespace AccountManager.Api.Controllers
{
    [Route("api/companies")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }


        public IActionResult GetCompanies()
        {
            var companies = _companyRepository.GetAll();
            var dtos = Map<IEnumerable<CompanyDto>>(companies);
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompany(string id)
        {
            var company = _companyRepository.GetByIdentifier(id);
            if (company == null) return NotFound();
            var dto = Map<CompanyDto>(company);
            return Ok(dto);
        }
    }
}
