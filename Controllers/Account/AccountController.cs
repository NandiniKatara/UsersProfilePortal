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
                        Response.Cookies.Append("Id", data.Id.ToString());
                        Response.Cookies.Append("Email", data.Email);
                        Response.Cookies.Append("Username", data.Username);
                        return RedirectToAction("Index", "User");
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

        public IActionResult ChangePassword()
        {
            int userId;
            if (!int.TryParse(Request.Cookies["Id"], out userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var user = context.AccountUsers.Find(userId);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new ChangePasswordViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            int userId;
            if (!int.TryParse(Request.Cookies["Id"], out userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var user = context.AccountUsers.Find(userId);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            user.Password = model.NewPassword;
            context.SaveChanges();

            // Redirect to the index page or any other page after changing the password
            return RedirectToAction("Index", "Home");
        }
    }
}
