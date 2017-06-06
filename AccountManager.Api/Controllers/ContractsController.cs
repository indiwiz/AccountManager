﻿using System;
using AccountManager.Api.Models;
using AccountManager.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountManager.DataAccess.Entities;
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
            return Ok(Map<IEnumerable<ContractReadDto>>(contracts));
        }

        [HttpGet("{id}")]
        public IActionResult GetContractForCompany(string identifier, int id)
        {
            var company = _companyRepository.GetByIdentifier(identifier);
            if (company == null) return NotFound();
            var contract = _contractRepository.GetContractForCompany(company.Id, id);
            if (contract == null) return NotFound();
            return Ok(Map<ContractReadDto>(contract));
        }

        [HttpPost()]
        public async Task<IActionResult> CreateContract(string identifier, [FromBody] ContractCreateDto contractCreateDto)
        {
            if (contractCreateDto == null) return BadRequest();

            var company = _companyRepository.GetByIdentifier(identifier);
            if (company == null) return NotFound();

            var contract = Map<Contract>(contractCreateDto);
            contract.CompanyId = company.Id;

            _contractRepository.CreateContract(contract);
            var saved = await _contractRepository.SaveChangesAsync();

            if (!saved) throw new Exception("Failed to create the Contract");

            var contractDto = Map<ContractReadDto>(contract);

            return CreatedAtAction(nameof(GetContractForCompany), new { identifier = company.Identifier, id = contract.Id }, contractDto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContract(string identifier, int id, [FromBody] ContractUpdateDto contractUpdateDto)
        {
            if (contractUpdateDto == null) return BadRequest();

            var company = _companyRepository.GetByIdentifier(identifier);
            if (company == null) return NotFound();

            var contract = _contractRepository.GetContractForCompany(company.Id, id);
            if (contract == null) return NotFound();

            Map(contractUpdateDto, contract);

            _contractRepository.UpdateContract(contract);

            var saved = await _contractRepository.SaveChangesAsync();

            if (!saved) throw new Exception("Failed to update the Contract");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContract(string identifier, int id)
        {
            var company = _companyRepository.GetByIdentifier(identifier);
            if (company == null) return NotFound();

            var contract = _contractRepository.GetContractForCompany(company.Id, id);
            if (contract == null) return NotFound();

            _contractRepository.DeleteContract(contract);

            var saved = await _contractRepository.SaveChangesAsync();

            if (!saved) throw new Exception("Failed to delete the Contract");

            return NoContent();
        }
    }
}
