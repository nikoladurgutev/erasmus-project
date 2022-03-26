using Erasmus.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Erasmus.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
