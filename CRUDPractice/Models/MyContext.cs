#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace CRUDPractice.Models;

public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }    
    public DbSet<Monster> Monsters { get; set; } 
}