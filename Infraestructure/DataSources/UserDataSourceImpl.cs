using Dapper;
using Domain.DataSources;
using Domain.Dto.Requests;
using Domain.Entities;
using Domain.Models;
using Infraestructure.Context;

namespace Infraestructure.DataSources;

public class UserDataSourceImpl(DapperContext context) : IUserDataSource
{
    public async Task<User> GetUser(Guid id)
    {
        using var connection = context.CreateConnection();
        const string query = "SELECT Id, Name, Email FROM Users WHERE Id = @Id AND deleted = false RETURNING Id, Name, Email";
        return await connection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
    }

    public async Task<User> GetUser(string email)
    {
<<<<<<< HEAD
        using var connection = _context.CreateConnection();
        var query = "SELECT * FROM Users WHERE email = @Email AND deleted = false";

        var user = await connection.QueryFirstOrDefaultAsync<User>(query, new { Email = email });
        return user; 
=======
        using var connection = context.CreateConnection();
        const string query = "SELECT Id, Name, Email FROM Users WHERE email = @Email AND deleted = false RETURNING Id, Name, Email";
        return await connection.QueryFirstOrDefaultAsync<User>(query, new { Email = email }); 
>>>>>>> ba709163bf6d6e2704b27ac779ace975487b22b3
    }

    public async Task<User> CreateUser(CreateUserDto user)
    {
        using var connection = context.CreateConnection();
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
        user.Password = hashedPassword;
        const string query = @"
                INSERT INTO Users (Name, Email, Password)
                VALUES (@Name, @Email, @Password)
                RETURNING Id, Name, Email";
        return await connection.QueryFirstOrDefaultAsync<User>(query, new
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,
        }); 

    }

    public Task<User> UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User> DeleteUser(Guid id)
    {
        using var connection = context.CreateConnection();
        const string query = "UPDATE Users SET deleted = true WHERE Id = @Id RETURNING Id, Name, Email";
        return await connection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        using var connection = context.CreateConnection();
        var query = "SELECT Id, Name, Email FROM Users WHERE deleted = false";
        return await connection.QueryAsync<User>(query); 
    }

    public Task<IEnumerable<Project>> GetUserProjects(Guid userId)
    {
        throw new NotImplementedException();
    }
}