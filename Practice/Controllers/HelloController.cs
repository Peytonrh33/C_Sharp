using Microsoft.AspNetCore.Mvc;
namespace Practice.Controllers;

public class HelloController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(string TextField, int NumberField)
    {
        Console.WriteLine($"My text was : {TextField}");
        Console.WriteLine($"My number was : {NumberField}");
        return RedirectToAction("Index");
    }
}
