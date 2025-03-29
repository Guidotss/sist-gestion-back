using Domain.DataSources;
using Domain.Dto.Requests;
using Domain.Entities;
using Domain.Models;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<User> GetUser(Guid id);
    Task<User> GetUser(string email);
    Task<User> CreateUser(CreateUserDto user);
    Task<User> UpdateUser(User user);
    Task<User> DeleteUser(Guid id);
    Task<IEnumerable<User>> GetUsers();
    Task<List<Project>> GetUserProjects(Guid userId);
}