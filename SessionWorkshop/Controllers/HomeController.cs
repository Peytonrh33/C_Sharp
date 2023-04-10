using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpPost("Register")]
    public IActionResult Register(User user)
    {
        if(ModelState.IsValid)
        {
            HttpContext.Session.SetString("User", $"{user.FirstName}");
            HttpContext.Session.SetInt32("Num", 22);
            return RedirectToAction("Dashboard", user);
        }
        return View("Index", user);
    }

    [HttpGet("Dashboard")]
    public ViewResult Dashboard()
    {
        
        return View("Dashboard");
    }

    [HttpPost("Num")]
    public IActionResult Num()
    {
        return RedirectToAction("Dashboard");
    }

    [HttpPost("function")]
    public IActionResult Function(string buttonType)
    {
        int origin = Convert.ToInt32(HttpContext.Session.GetInt32("Num"));
        if(buttonType == "Plus")
        {
            int button = origin + 1;
            HttpContext.Session.SetInt32("Num", button);
        }
        else if(buttonType == "Minus")
        {
            int button = origin - 1;
            HttpContext.Session.SetInt32("Num", button);
        }
        else if(buttonType == "Times")
        {
            int button = origin * 2;
            HttpContext.Session.SetInt32("Num", button);
        }
        else if(buttonType == "Random")
        {
            Random rand = new Random();
            int button = origin += rand.Next(0,10);
            HttpContext.Session.SetInt32("Num", button);
        }
        return RedirectToAction("Dashboard");
    }

    [HttpPost("clear")]
    public IActionResult ClearSession()
    {
        HttpContext.Session.Clear();
        HttpContext.Session.SetInt32("Num", 22);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
