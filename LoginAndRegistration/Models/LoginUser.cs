#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace LoginAndRegistration.Models;
public class LoginUser
{
    [Required]
    public string LEmail {get;set;}

    [Required]
    public string LPassword {get;set;}
}