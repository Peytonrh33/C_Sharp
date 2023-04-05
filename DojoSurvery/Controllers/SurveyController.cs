using Microsoft.AspNetCore.Mvc;
namespace Practice.Controllers;
using DojoSurvery.Models;


public class SurveyController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpPost("process")]
    public IActionResult Process(Survey survey)
    {
        HttpContext.Session.SetString("Name", $"{survey.Name}");
        HttpContext.Session.SetString("Location", $"{survey.Location}");
        HttpContext.Session.SetString("Language", $"{survey.Language}");
        HttpContext.Session.SetString("Comment", $"{survey.Comment}");
        return RedirectToAction("Display");

    }
    [HttpGet("results")]
    public ViewResult Display()
    {
        return View("Display");
    }
}