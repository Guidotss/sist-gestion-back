using Dapper;
using Domain.DataSources;
using Domain.Dto.Requests;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using Infraestructure.Context;

namespace Infraestructure.DataSources;

public class AuthDataSourceImpl(DapperContext _context, IUserRepository _userRepository) : IAuthDataSource
{

    public async Task<User> Register(CreateUserDto user)
    {
        var checkUser = await _userRepository.GetUser(user.Email);
        if (checkUser != null) throw new CustomException("User already exists", 400);
    
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
        var newUser = new User  
        {
            Id = Guid.NewGuid(),
            Name = user.Name,
            Email = user.Email,
            Password = hashedPassword,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    
        using var connection = _context.CreateConnection();

        var query = @"
        INSERT INTO Users (Id, Name, Email, Password, created_at, updated_at) 
        VALUES (@Id, @Name, @Email, @Password, @CreatedAt, @UpdatedAt) 
        RETURNING Id, Name, Email;
    ";
    
        var result = await connection.QuerySingleAsync<User>(query, new
        {
            newUser.Id,
            newUser.Name,
            newUser.Email,
            newUser.Password,
            CreatedAt = newUser.CreatedAt,
            UpdatedAt = newUser.UpdatedAt
        }); 

        return result; 
    }


    public async Task<User> Login(LoginDto user)
    {
        var checkUser = await _userRepository.GetUser(user.Email);

        if(checkUser == null)
        {
            throw new CustomException("Invalid credentials", 400);
        }
        bool checkPassword = BCrypt.Net.BCrypt.Verify(user.Password, checkUser.Password);
        
        if(!checkPassword)
        {
            throw new CustomException("Invalid credentials", 400);
        }
        var loggedUser = new User
        {
            Id = checkUser.Id,
            Name = checkUser.Name,
            Email = checkUser.Email
        };
        
        return loggedUser;
    }

}