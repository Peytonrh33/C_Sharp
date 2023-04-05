#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurvery.Models;
public class Survey
{
    [Required(ErrorMessage ="Name is Required!")]
    [MinLength(2, ErrorMessage ="Name bust be at least 2 characters!")]
    public string Name {get;set;}
    [Required(ErrorMessage ="Location is Required!")]
    public string Location {get;set;}
    [Required(ErrorMessage ="Language is Required!")]
    public string Language {get;set;}
    public string Comment {get;set;}
}