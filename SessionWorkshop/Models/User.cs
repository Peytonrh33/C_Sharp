#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace SessionWorkshop.Models;

public class User
{
    [Required(ErrorMessage = "First Name is Reauired!")]
    [MinLength(2, ErrorMessage ="Minimum 2 characters!")]
    public string FirstName {get;set;}
}