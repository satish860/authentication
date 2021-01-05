using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Basic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public async  Task<IActionResult> Authenticate()
        {
            var defaultClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"satish")
            };
            var defaultIdentityprovider = new ClaimsIdentity(defaultClaims, "default");
            var userPrincipal = new ClaimsPrincipal(defaultIdentityprovider);
            await HttpContext.SignInAsync(userPrincipal);
            return RedirectToAction("Home");
        }
    }
}
