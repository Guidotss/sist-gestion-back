using Domain.DataSources;
using Domain.Entities;
using Domain.Models;
using Domain.Repositories;
using Infraestructure.DataSources;

namespace Infraestructure.Repositories;

public class UserRepositoryImpl(IUserDataSource dataSource) : IUserRepository
{
    public Task<User> GetUser(Guid id)
    {
        return dataSource.GetUser(id);
    }

    public Task<User> GetUser(string email)
    {
        return dataSource.GetUser(email);
    }

    public Task<User> CreateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetUsers()
    {
        return dataSource.GetUsers();
    }

    public Task<List<Project>> GetUserProjects(Guid userId)
    {
        throw new NotImplementedException();
    }
}