using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Portal.Data;
using Portal.Models;
using Portal.Models.Account;
using Portal.Models.ViewModel;
using System.Security.Claims;

namespace Portal.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext context;
        public AccountController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = context.AccountUsers.Where(e => e.Username == model.Username).SingleOrDefault();
                if (data != null)
                {
                    bool isValid = (data.Username == model.Username && data.Password == model.Password);
                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Name, model.Username) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Username", model.Username);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["errorPassword"] = "Invalid password !";
                        return View(model);
                    }
                }


                else
                {
                    TempData["errorUsername"] = "Username not found";
                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedCookies = Request.Cookies.Keys;
            foreach (var cookies in storedCookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("Login", "Account");
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(SignUpUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = new AccountUser()
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    //ContactNumber=model.ContactNumber,
                    IsActive = model.IsActive,
                };
                context.AccountUsers.Add(data);
                context.SaveChanges();
                TempData["successMessage"] = "SignUp is completed successfully!" +
                    " Fill credentials to login";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["errorMessage"] = "Fill to submit !";
                return View(model);
            }
        }
    }
}
