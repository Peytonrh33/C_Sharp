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
            return RedirectToAction("Display", survey);
        }
        else
        {
            return View("Index", survey);
        }

    }
    [HttpGet("results")]
    public ViewResult Display(Survey survey)
    {
        return View("Display", survey);
    }
}