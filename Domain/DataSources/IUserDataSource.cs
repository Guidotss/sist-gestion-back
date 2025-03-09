using Domain.Entities;
using Domain.Models;

namespace Domain.DataSources;

public interface IUserDataSource
{
    Task<User> GetUser(Guid id);
    Task<User> GetUser(string email);
    Task<User> CreateUser(User user);
    Task<User> UpdateUser(User user);
    Task<User> DeleteUser(Guid id);
    Task<List<User>> GetUsers();
    Task<List<Project>> GetUserProjects(Guid userId);
}