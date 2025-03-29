using Domain.Dto.Requests;
using Domain.Models;

namespace Domain.DataSources;

public interface IAuthDataSource
{
    Task<User> Register(CreateUserDto user);
    Task<User> Login(LoginDto user);
}