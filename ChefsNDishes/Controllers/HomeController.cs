using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    // ==========================================================Chef Index

    [HttpGet("/")]
    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs.Include(d=> d.AllDishes).OrderByDescending(c => c.CreatedAt).ToList();
        // int numDishes = _context.Chefs.Include(chef => chef.AllDishes).FirstOrDefault(c => c.ChefId == chefId).AllDishes.Count;
        return View("Index", AllChefs);
    }

// ===============================================================Create a Chef
    [HttpGet("/chef/new")]
    public IActionResult ChefPage()
    {
        return View("NewChef");
    }

    [HttpPost("/chefs/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else{
            return View("Chef");
        }
    }

// ===============================================================Dish Index
    [HttpGet("/dishes")]
    public IActionResult DishIdx()
    {
        List<Dish> AllDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).Include(c=> c.Chef).ToList();
        return View("DishIndex", AllDishes);
    }

// ===============================================================Create a Dish
    [HttpGet("/dishes/new")]
    public IActionResult NewDish()
    {
        ViewBag.AllChefs = _context.Chefs.OrderByDescending(c => c.CreatedAt).ToList();
        return View("NewDish");
    }

    [HttpPost("/dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("DishIdx");
        } else {
            return View("NewDish");
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
