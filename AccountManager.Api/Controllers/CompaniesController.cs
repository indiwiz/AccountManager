using System;
using AccountManager.Api.Models;
using AccountManager.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountManager.DataAccess.Entities;
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

        [HttpGet("{id}", Name = "GetCompany")]
        public IActionResult GetCompany(string id)
        {
            var company = _companyRepository.GetByIdentifier(id);
            if (company == null) return NotFound();
            var dto = Map<CompanyDto>(company);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody]CreateCompanyDto createCompanyDto)
        {
            if (createCompanyDto == null) return BadRequest();
            var company = Map<Company>(createCompanyDto);
            _companyRepository.Create(company);

            var saved = await _companyRepository.SaveChangesAsync();
            if (!saved) throw new Exception("Failed to create the Company");

            var companyDto = Map<CompanyDto>(company);

            return CreatedAtAction(nameof(GetCompany), new { id = company.Identifier }, companyDto);
        }
    }
}
