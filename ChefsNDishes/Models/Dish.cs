#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;

public class Dish
{
    [Key]
    public int DishId {get;set;}

    [Required]
    public string Name {get;set;}
    
    [Required]
    public string Tastiness {get;set;}

    [Required]
    public int Calories {get;set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int ChefId {get;set;}

    // !! Navigation Property
    public Chef? Chef {get;set;}
}