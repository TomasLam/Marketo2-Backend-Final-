using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketoTest2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        
        public IActionResult AdminPage()
        {
            return View();
        }
        
        public IActionResult ManageUsers()
        {
            return View();
        }
    }
    
}
