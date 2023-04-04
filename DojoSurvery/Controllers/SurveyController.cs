using Microsoft.AspNetCore.Mvc;
namespace Practice.Controllers;


public class SurveyController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpPost("process")]
    public IActionResult Process(string Name, string Location, string Language, string Comment)
    {
        Console.WriteLine($"{Name}");
        Console.WriteLine($"{Location}");
        Console.WriteLine($"{Language}");
        Console.WriteLine($"{Comment}");
        HttpContext.Session.SetString("Name", $"{Name}");
        HttpContext.Session.SetString("Location", $"{Location}");
        HttpContext.Session.SetString("Language", $"{Language}");
        HttpContext.Session.SetString("Comment", $"{Comment}");
        return RedirectToAction("Display");

    }
    [HttpGet("results")]
    public ViewResult Display()
    {
        return View("Display");
    }
}