using Microsoft.AspNetCore.Mvc;
using MarketoTest2.Models;
using MarketoTest2.Data;
using System.Diagnostics;

namespace MarketoTest2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;  // Lägg till DbContext

        // Lägg till konstruktor för att injicera ApplicationDbContext
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;  // Injektion av DbContext
        }

        // Denna metod hämtar produkter och skickar dem till vyn
        public IActionResult Index()
        {
            // Hämta alla produkter från databasen
            var products = _context.Products.ToList(); // Förutsätter att du har en Products DbSet

            // Skicka listan av produkter till vyn
            return View(products);
        }

        // Övriga action-metoder
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult RegSite()
        {
            return View();
        }

        public IActionResult ProductDetail()
        {
            return View();
        }

        // Error-handling
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
