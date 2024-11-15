using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MarketoTest2.Data;
using MarketoTest2.Models;
using System.Threading.Tasks;

public class ContactController : Controller
{
    private readonly ApplicationDbContext _context;

    public ContactController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Contact()
    {
        return View();
    }

  
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Contact(ContactForm contactForm)
    {
        if (ModelState.IsValid)
        {
            _context.ContactForms.Add(contactForm);
            await _context.SaveChangesAsync();
            return RedirectToAction("ContactConfirmation");
        }
        return View(contactForm);
    }

    public IActionResult ContactConfirmation()
    {
        return View();
    }

    public IActionResult Index() => View();
    public IActionResult LogIn() => View();
    public IActionResult RegSite() => View();
    public IActionResult ProductDetail() => View();
}
