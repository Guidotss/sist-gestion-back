using Domain.Entities;


namespace Domain.Models;

public class User: BaseEntity
{
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Project> Projects { get; set; } = new List<Project>(); 
}