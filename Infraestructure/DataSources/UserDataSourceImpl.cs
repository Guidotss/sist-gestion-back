using Dapper;
using Domain.DataSources;
using Domain.Dto.Requests;
using Domain.Entities;
using Domain.Models;
using Infraestructure.Context;

namespace Infraestructure.DataSources;

public class UserDataSourceImpl : IUserDataSource
{
    private readonly DapperContext _context;

    public UserDataSourceImpl(DapperContext context)
    {
        _context = context;
    }
    public async Task<User> GetUser(Guid id)
    {
        using var connection = _context.CreateConnection();
        var query = "SELECT * FROM Users WHERE Id = @Id AND deleted = false";
        return await connection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
    }

    public async Task<User> GetUser(string email)
    {
        using var connection = _context.CreateConnection();
        var query = "SELECT * FROM Users WHERE email = @Email AND deleted = false";
        return await connection.QueryFirstOrDefaultAsync<User>(query, new { Email = email }); 
    }

    public Task<User> CreateUser(CreateUserDto user)
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

    public async Task<IEnumerable<User>> GetUsers()
    {
        using var connection = _context.CreateConnection();
        var query = "SELECT * FROM Users WHERE deleted = false";
        return await connection.QueryAsync<User>(query); 
    }

    public Task<IEnumerable<Project>> GetUserProjects(Guid userId)
    {
        throw new NotImplementedException();
    }
}