using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcoRouter.Data;
using EcoRouter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using EcoRouter.Encrypt;

namespace EcoRouter.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private RouterContext _context;

        public LoginController(RouterContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        async public Task<ActionResult> Authorize(UserModel user)
        {
            DataService service = new DataService(_context);

            var users = service.GetUsers();

            var VM = new LoginViewModel();

            if (!users.Any(a => a.UserName == user.UserName))
            {
                VM.LoginErrorMessage = "Wrong username";
                return View("Index", VM);
            }
            else
            {
                if (!users.Any(a => Decryptor.Decrypt(a.Password) == user.Password))
                {
                    VM.LoginErrorMessage = "Wrong password";
                    return View("Index", VM);
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName)
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties { };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}