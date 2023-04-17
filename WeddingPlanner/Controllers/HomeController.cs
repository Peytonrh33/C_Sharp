using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

// ================================================================= Render Register/Login Page =======================User login and create
    [HttpGet("/")]
    public IActionResult Index()
    {
        return View("Index");
    }

// ================================================================= Registers/Creates User
    [HttpPost("/users/create")]
        public IActionResult CreateUser(User newUser)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);

                _context.Add(newUser);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                HttpContext.Session.SetString("UserName", newUser.FirstName);
                return RedirectToAction("Weddings");
            } else{
                return View("Index");
            }
        }

// ======================================================================Form for the login
    [HttpPost("/users/login")]
    public IActionResult LoginUser(LoginUser userSubmission)
    {
        if(ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.LEmail);
            if(userInDb == null)
            {
                ModelState.AddModelError("LEmail", "Invalid Email/Password");
                return View("Index");
            }

            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();

            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LPassword);

            if(result == 0)
            {
                ModelState.AddModelError("LPassword", "Invalid Email/Password");
                return View("Index");
            } else{
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                HttpContext.Session.SetString("UserName", userInDb.FirstName);
                return RedirectToAction("Weddings");
            }
        } else {
            return View("Index");
        }
    }


// =================================================================Logout Button
    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

// ==========================================================================================================This is the weddings stuff
    [SessionCheck]
    [HttpGet("/weddings")]
    public IActionResult Weddings()
    {
        MyViewModel MyModel = new MyViewModel()
        {
            AllWeddings = _context.Weddings.Include(w => w.Guests).ThenInclude(g => g.User).ToList(),
            Wedding = new Wedding()
        };
        return View("Weddings", MyModel);
    }

// ========================================================================Create Wedding
    [SessionCheck]
    [HttpGet("/weddings/new")]
    public IActionResult WeddingNew(Wedding newWedding)
    {
        return View("CreateWedding");
    }

    [SessionCheck]
    [HttpPost("/weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        newWedding.UserId = (int)HttpContext.Session.GetInt32("UserId");
        if(ModelState.IsValid)
        {
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Weddings");
        }
        else 
        {
            return View("CreateWedding");
        }
    }

    [SessionCheck]
    [HttpGet("/weddings/{id}")]
    public IActionResult Guests(int id)
    {
        ViewBag.OneWedding = _context.Weddings.FirstOrDefault(w => w.WeddingId == id);
        MyViewModel Guests = new MyViewModel()
        {
            AllGeusts = _context.Guests.Where(w => w.WeddingId == id).Include(g => g.User).ToList(),
            Guest = new Guest()
        };
        return View("WeddingGuest", Guests);
    }


// ========================================================Actions

    [SessionCheck]
    [HttpPost("/weddings/{id}/destroy")]
    public IActionResult DestroyWedding(int id)
    {
        Wedding? WeddingToDelete = _context.Weddings.SingleOrDefault(w => w.WeddingId == id);
        _context.Weddings.Remove(WeddingToDelete);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }

    [SessionCheck]
    [HttpPost("/weddings/{id}/rsvp")]
    public IActionResult RSVP(Guest newGuest, int id)
    {
        newGuest.WeddingId = id;
        newGuest.UserId = (int)HttpContext.Session.GetInt32("UserId");
        _context.Add(newGuest);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }

    [SessionCheck]
    [HttpPost("/weddings/{id}/rsvp/destroy")]
    public IActionResult UnRSVP(int id)
    {
        Guest? GuestToDelete = _context.Guests.FirstOrDefault(g => g.WeddingId == id && g.UserId == (int)HttpContext.Session.GetInt32("UserId"));
        _context.Guests.Remove(GuestToDelete);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
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


public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        if(userId == null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}