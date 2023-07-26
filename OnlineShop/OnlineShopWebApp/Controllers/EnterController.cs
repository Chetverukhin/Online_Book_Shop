using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class EnterController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public EnterController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Authorization(string returnUrl)
        {
            return View(new Authorization() { ReturnUrl = returnUrl });
        }

        public IActionResult Registration(string returnUrl)
        {
            return View(new Registration() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Authorization(Authorization authorizationInfo)
        {
            var user = _userManager.FindByEmailAsync(authorizationInfo.Login).Result;

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Пользователя с таким логином не существует");
            }

            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(
                    user,
                    authorizationInfo.Password,
                    authorizationInfo.RememberMe,
                    false).Result;

                if (result.Succeeded)
                {
                    return authorizationInfo.ReturnUrl == null
                        ? RedirectToAction("Index", "Home")
                        : Redirect(authorizationInfo.ReturnUrl);
                }

                ModelState.AddModelError(string.Empty, "Неправильный пароль");
            }

            return View(authorizationInfo);
        }

        [HttpPost]
        public IActionResult Registration(Registration registration)
        {

            if (registration.Name == registration.LastName)
            {
                ModelState.AddModelError(string.Empty, "Имя и Фамилия не должны совпадать");
            }

            if (_userManager.FindByEmailAsync(registration.Email).Result != null)
            {
                ModelState.AddModelError(string.Empty, "Пользователь с таким email уже существует");
            }

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = registration.Name,
                    Email = registration.Email,
                    PhoneNumber = registration.Phone,
                };

                var result = _userManager.CreateAsync(user, registration.Password).Result;

                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait();
                    return Redirect(registration.ReturnUrl ?? "/Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(registration);
        }
    }
}
