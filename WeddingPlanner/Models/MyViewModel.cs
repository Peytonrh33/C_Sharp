#pragma warning disable CS8618\
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

public class MyViewModel
{
    public User? User { get; set; }
    public List<User> AllUsers { get; set; }

    public Wedding? Wedding { get; set; }
    public List<Wedding> AllWeddings { get; set; }

    public Guest? Guest { get; set; }
    public List<Guest> AllGeusts { get; set; }


}