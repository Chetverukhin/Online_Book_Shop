using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Constant.AdminRoleName)]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _rolesManager;

        public RolesController(RoleManager<IdentityRole> rolesManager)
        {
            _rolesManager = rolesManager;
        }

        public IActionResult Index()
        {
            var model = new RoleManagingViewModel
            {
                Roles = _rolesManager.Roles.ToList().Select(Mapping.ToRoleViewModel).ToList(),
                Role = new RoleViewModel(),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddRole(RoleViewModel newRole)
        {
            if (_rolesManager.RoleExistsAsync(newRole.Name).Result)
            {
                ModelState.AddModelError("ErrorExist", "Роль уже существует!");
            }

            if (ModelState.IsValid)
            {
                var result = _rolesManager.CreateAsync(new IdentityRole(newRole.Name)).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Roles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            var model = new RoleManagingViewModel
            {
                Roles = _rolesManager.Roles.ToList().Select(Mapping.ToRoleViewModel).ToList(),
                Role = newRole
            };

            return RedirectToAction("Index", "Roles", model);
        }

        public IActionResult DeleteRole(string roleId)
        {
            var deleteRole = _rolesManager.FindByIdAsync(roleId).Result;

            if (deleteRole.Name is Constant.AdminRoleName or Constant.UserRoleName)
            {
                ModelState.AddModelError(string.Empty, "Эту роль удалять нельзя");
            }

            if (ModelState.IsValid)
            {
                var result = _rolesManager.DeleteAsync(deleteRole).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Roles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            var model = new RoleManagingViewModel
            {
                Roles = _rolesManager.Roles.ToList().Select(Mapping.ToRoleViewModel).ToList(),
                Role = new RoleViewModel { Id = roleId }
            };

            return RedirectToAction("Index", "Roles", model);
        }

        public IActionResult EditRole(RoleViewModel editRole)
        {
            if (_rolesManager.RoleExistsAsync(editRole.Name).Result)
            {
                ModelState.AddModelError("ErrorExist", "Роль уже существует!");
            }

            if (ModelState.IsValid)
            {
                var existRole = _rolesManager.FindByIdAsync(editRole.Id).Result;

                existRole.Name = editRole.Name;

                var result = _rolesManager.UpdateAsync(existRole).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Roles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            var model = new RoleManagingViewModel
            {
                Roles = _rolesManager.Roles.ToList().Select(Mapping.ToRoleViewModel).ToList(),
                Role = editRole
            };

            return RedirectToAction("Index", "Roles", model);
        }
    }
}
