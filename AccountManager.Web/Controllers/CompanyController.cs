using AccountManager.DataAccess.Entities;
using AccountManager.DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AccountManager.Web.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyService;

        public CompanyController(ICompanyRepository companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            var companies = _companyService.GetAll();
            return View(companies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            await _companyService.Create(company);
            return RedirectToAction("Details", new { id = company.Identifier });
        }

        public IActionResult Details(string id)
        {
            var company = _companyService.GetByIdentifier(id);
            if (company == null) return NotFound();
            return View(company);
        }
    }
}