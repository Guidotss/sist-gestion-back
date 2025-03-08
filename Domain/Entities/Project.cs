using Domain.Models;

namespace Domain.Entities;


public enum ProjectStatus
{
    Active,
    Inactive,
    Archived
}

public class Project: BaseEntity
{ 
    public User Owner { get; set; }
    public string? Repository { get; set; }
    public ProjectStatus Status { get; set; }
    public List<User> Collaborators { get; set; } = new List<User>(); 
}