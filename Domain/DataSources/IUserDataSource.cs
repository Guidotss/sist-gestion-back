using Domain.Dto.Requests;
using Domain.Entities;
using Domain.Models;

namespace Domain.DataSources;

public interface IUserDataSource
{
    Task<User> GetUser(Guid id);
    Task<User> GetUser(string email);
    Task<User> CreateUser(CreateUserDto user);
    Task<User> UpdateUser(User user);
    Task<User> DeleteUser(Guid id);
    Task<IEnumerable<User>> GetUsers();
    Task<IEnumerable<Project>> GetUserProjects(Guid userId);
}