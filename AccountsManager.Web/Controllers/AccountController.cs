using Microsoft.AspNetCore.Mvc;

namespace AccountsManager.Web.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ViewResult Register()
        {
            return View();
        }
    }
}
