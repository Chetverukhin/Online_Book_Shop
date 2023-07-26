using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constant.AdminRoleName)]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _usersManager;
        private readonly RoleManager<IdentityRole> _rolesManager;

        public UsersController(UserManager<User> usersManager, RoleManager<IdentityRole> rolesManager)
        {
            _usersManager = usersManager;
            _rolesManager = rolesManager;
        }

        public IActionResult Index()
        {
            var model = _usersManager.Users.ToList();
            var users = model.Select(Mapping.ToUserViewModel).ToList();

            return View(users);
        }

        public IActionResult UserCard(string userId)
        {
            var user = Mapping.ToUserViewModel(_usersManager.FindByIdAsync(userId).Result);

            return View(user);
        }

        public IActionResult EditUser(string userId)
        {
            var user = Mapping.ToUserViewModel(_usersManager.FindByIdAsync(userId).Result);

            return View(user);
        }

        [HttpPost]
        public IActionResult EditUser(UserViewModel editUser)
        {
            if (editUser.LastName != null && editUser.UserName.ToLower().Equals(editUser.LastName.ToLower()))
            {
                ModelState.AddModelError(string.Empty, "Имя не должно совпадать с Фамилией");
            }

            if (ModelState.IsValid)
            {
                var existUser = _usersManager.FindByIdAsync(editUser.Id).Result;

                existUser.UserName = editUser.UserName;
                existUser.LastName = editUser.LastName;
                existUser.Patronymic = editUser.Patronymic;
                existUser.Email = editUser.Email;
                existUser.PhoneNumber = editUser.PhoneNumber;
                existUser.BirthDate = editUser.BirthDate;
                existUser.Gender = editUser.Gender;

                var result = _usersManager.UpdateAsync(existUser).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("UserCard", "Users", new { userId = editUser.Id });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(editUser);
        }

        public IActionResult DeleteUser(string userId)
        {
            var user = _usersManager.FindByIdAsync(userId).Result;
            _usersManager.DeleteAsync(user).Wait();

            return RedirectToAction("Index", "Users");
        }

        public IActionResult ChangePassword(string userId)
        {
            var user = _usersManager.FindByIdAsync(userId).Result;

            var model = new ChangePassword()
            {
                Id = userId,
                Password = user.PasswordHash,
                ConfirmPassword = user.PasswordHash,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword newPassword)
        {
            var existUser = _usersManager.FindByIdAsync(newPassword.Id).Result;

            if (newPassword.Password.Equals(existUser.Email))
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
            }

            if (ModelState.IsValid)
            {
                existUser.PasswordHash = _usersManager.PasswordHasher.HashPassword(existUser, newPassword.Password);

                var result = _usersManager.UpdateAsync(existUser).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("UserCard", "Users", new { userId = existUser.Id });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(newPassword);
        }

        public IActionResult SetRole(string userId)
        {
            var existUser = _usersManager.FindByIdAsync(userId).Result;
            var currentUserRoleName = _usersManager.GetRolesAsync(existUser).Result.FirstOrDefault();

            var role = new RoleViewModel()
            {
                UserId = existUser.Id,
                CurrentName = currentUserRoleName,
                Name = currentUserRoleName,
                Description = string.Empty,
                RoleSelectListItems = _rolesManager.Roles.Select(role => new SelectListItem { Value = role.Name, Text = role.Name }).ToList()
            };

            return View(role);
        }

        [HttpPost]
        public IActionResult SetRole(RoleViewModel role)
        {
            var existUser = _usersManager.FindByIdAsync(role.UserId).Result;
            var currentRoleName = role.CurrentName;
            var newRoleName = role.Name;

            if (_usersManager.GetUsersInRoleAsync(newRoleName).Result.Any() && newRoleName != currentRoleName)
            {
                ModelState.AddModelError("", "Роль уже существует!");
            }

            if (ModelState.IsValid)
            {
                if (currentRoleName != null)
                {
                    _usersManager.RemoveFromRoleAsync(existUser, currentRoleName).Wait();
                }

                _usersManager.AddToRoleAsync(existUser, newRoleName).Wait();

                var result = _usersManager.UpdateAsync(existUser).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("UserCard", "Users", new { userId = existUser.Id });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            role.RoleSelectListItems = _rolesManager.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();

            return View(role);
        }
    }
}
