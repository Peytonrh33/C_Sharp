using Microsoft.AspNetCore.Mvc;
namespace DojoSurvery.Controllers;
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
        if(ModelState.IsValid)
        {
            HttpContext.Session.SetString("Name", $"{survey.Name}");
            HttpContext.Session.SetString("Location", $"{survey.Location}");
            HttpContext.Session.SetString("Language", $"{survey.Language}");
            HttpContext.Session.SetString("Comment", $"{survey.Comment}");
            return RedirectToAction("Display");
        }
        else
        {
            return View("Index", survey);
        }

    }
    [HttpGet("results")]
    public ViewResult Display()
    {
        return View("Display");
    }
}