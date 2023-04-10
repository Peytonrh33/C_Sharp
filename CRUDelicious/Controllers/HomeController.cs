using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // =================================================This is the beginning page with all of the dishes

    [HttpGet("/")]
    public IActionResult Index()
    {
        ViewBag.AllDishes = _context.Dishes.ToList();

        return View("Index");
    }

    // ===================================================This the render/create page

    [HttpGet("/dishes/new")]
    public ViewResult NewDish()
    {
        return View("New");
    }

    [HttpPost("/dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("New");
    }

    // ===================================================This will be the view one page
    [HttpGet("/dishes/{id}")]
    public IActionResult ShowItem(int id)
    {
        ViewBag.One_dish = _context.Dishes.FirstOrDefault(a => a.DishId == id);

        return View("Show");
    }

    // ====================================================Edit page
    [HttpGet("/dishes/{id}/edit")]
    public IActionResult EditDish(int id)
    {
        ViewBag.One_dish = _context.Dishes.FirstOrDefault(a => a.DishId == id);
        return View("Edit");
    }
    [HttpPost("/dishes/{DishId}/update")]
    public IActionResult UpdateDish(int DishId, Dish NewVersion)
    {
        Dish? Old_Dish = _context.Dishes.FirstOrDefault(a => a.DishId == DishId);
        if(ModelState.IsValid)
        {
            Old_Dish.Name = NewVersion.Name;
            Old_Dish.Chef = NewVersion.Chef;
            Old_Dish.Calories = NewVersion.Calories;
            Old_Dish.Tastiness = NewVersion.Tastiness;
            Old_Dish.Description = NewVersion.Description;
            Old_Dish.UpdatedAt = NewVersion.UpdatedAt;
            _context.SaveChanges();
            return RedirectToAction("Index");
        } 
        else
        {
            return View("Edit",Old_Dish);
        }
    }

    // ========================================================================Delete
    [HttpPost("dishes/{id}/destroy")]
    public IActionResult DestroyDish(int id)
    {
        Dish? DishToDelete = _context.Dishes.SingleOrDefault(i => i.DishId == id);
        _context.Dishes.Remove(DishToDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
