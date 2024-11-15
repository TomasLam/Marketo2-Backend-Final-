using Microsoft.AspNetCore.Mvc;
using MarketoTest2.Data;
using MarketoTest2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Index-metod för att visa produkter i olika kategorier
public async Task<IActionResult> Index()
{
    // Hämta kategorier som används för att filtrera produkter
    var newCategory = await _context.Categories
        .FirstOrDefaultAsync(c => c.Name == "New");
    var popularCategory = await _context.Categories
        .FirstOrDefaultAsync(c => c.Name == "Popular");
    var featuredCategory = await _context.Categories
        .FirstOrDefaultAsync(c => c.Name == "Featured");

    if (newCategory == null || popularCategory == null || featuredCategory == null)
    {
        return NotFound("One or more categories were not found.");
    }

    // Hämta produkter för varje kategori
    var newProducts = await _context.Products
        .Where(p => p.ProductCategories.Any(pc => pc.CategoryId == newCategory.Id))
        .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
        .ToListAsync();

    var popularProducts = await _context.Products
        .Where(p => p.ProductCategories.Any(pc => pc.CategoryId == popularCategory.Id))
        .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
        .ToListAsync();

    var featuredProducts = await _context.Products
        .Where(p => p.ProductCategories.Any(pc => pc.CategoryId == featuredCategory.Id))
        .Include(p => p.ProductCategories)
            .ThenInclude(pc => pc.Category)
        .ToListAsync();

    // Skapa HomeViewModel med produkterna
    var model = new HomeViewModel
    {
        NewProducts = newProducts,
        PopularProducts = popularProducts,
        FeaturedProducts = featuredProducts
    };

    // Skicka modellen till vyn
    return View(model);
}

    // Visa detaljer om en produkt
    public async Task<IActionResult> Details(int id)
    {
        var product = await _context.Products
            .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound("Product not found.");
        }

        return View(product);
    }

    // Metod för att skapa produkt
    public IActionResult Create()
    {
        ViewData["Categories"] = _context.Categories.ToList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product, List<int> categoryIds)
    {
        if (ModelState.IsValid)
        {
            // Lägg till produktkategorier baserat på valda kategorier
            product.ProductCategories = new List<ProductCategory>();

            foreach (var categoryId in categoryIds)
            {
                var category = await _context.Categories.FindAsync(categoryId);
                if (category != null)
                {
                    product.ProductCategories.Add(new ProductCategory
                    {
                        Product = product,
                        Category = category
                    });
                }
            }

            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Om ModelState inte är giltigt, ladda om kategorierna
        ViewData["Categories"] = _context.Categories.ToList();
        return View(product);
    }
}
