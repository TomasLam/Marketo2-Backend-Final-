using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketoTest2.Models;

namespace MarketoTest2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BackofficeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public BackofficeController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> UserList()
        {
             var users = _userManager.Users.ToList();
            var userRoles = new List<UserWithRolesViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                  userRoles.Add(new UserWithRolesViewModel
                {
                     Id = user.Id,
                    Email = user.Email,
                   Roles = roles
                });
            }

            return View(userRoles);
        }
    }
}
