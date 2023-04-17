#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;

public class Wedding 
{
    [Key]
    public int WeddingId {get;set;}

    [Required(ErrorMessage = "Wedder One is Required!")]
    public string WedderOne {get;set;}

    [Required(ErrorMessage = "Wedder Two is Required!")]
    public string WedderTwo {get;set;}

    public DateOnly Date {get;set;}

    [Required(ErrorMessage = "Address is Required!")]
    public string Address {get;set;}

    [ForeignKey("User")]
    public int UserId {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<Guest> Guests {get;set;} = new List<Guest>();
}