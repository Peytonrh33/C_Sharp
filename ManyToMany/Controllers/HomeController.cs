using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ManyToMany.Models;

namespace ManyToMany.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

// ==============================================================Product List and Create
    [HttpGet("/")]
    public IActionResult Index()
    {
        ViewBag.AllProducts = _context.Products.ToList();
        return View("Index");
    }

    [HttpPost("/products/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("Index");
        }
    }

    // ===========================================================Category List and Create

    [HttpGet("/categories")]
    public IActionResult Category()
    {
        ViewBag.AllCategories = _context.Categories.ToList();
        return View("Category");
    }

    [HttpPost("/category/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Category");
        }
        else
        {
            return View("Category");
        }
    }

    // ============================================================Product View one with categories
    [HttpGet("/products/{id}")]
    public IActionResult ProductCat(int id)
    {
        ViewBag.AllAssociations = _context.Products.Include(a => a.Products).ThenInclude(a => a.Category).FirstOrDefault(p => p.ProductId == id);
        ViewBag.OneProduct = _context.Products.FirstOrDefault(p => p.ProductId == id);
        ViewBag.AllCategories = _context.Categories.ToList();
        return View("ProductView");
    }

    [HttpPost("/products/{ProductId}/categories")]
    public IActionResult ProductCategory(int ProductId, Association newAssociation)
    {
        newAssociation.ProductId = ProductId;
        if(ModelState.IsValid)
        {
            _context.Add(newAssociation);
            _context.SaveChanges();
            return ProductCat(ProductId);
        }
        else
        {
            return ProductCat(ProductId);
        }
        
    }

    // ==================================================================Category View One with Products
    [HttpGet("/categories/{id}")]
    public IActionResult CatProd(int id)
    {
        ViewBag.AllAssociations = _context.Categories.Include(a => a.Categories).ThenInclude(a => a.Product).FirstOrDefault(p => p.CategoryId == id);
        ViewBag.OneCategory = _context.Categories.FirstOrDefault(p => p.CategoryId == id);
        ViewBag.AllProducts = _context.Products.ToList();
        return View("CategoryView");
    }

    [HttpPost("/categories/{CategoryId}/products")]
    public IActionResult CategoryProduct(int CategoryId, Association newAssociation)
    {
        newAssociation.CategoryId = CategoryId;
        if(ModelState.IsValid)
        {
            _context.Add(newAssociation);
            _context.SaveChanges();
            return CatProd(CategoryId);
        }
        else
        {
            return CatProd(CategoryId);
        }
        
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
