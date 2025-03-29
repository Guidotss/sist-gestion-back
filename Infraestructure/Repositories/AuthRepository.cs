using Domain.DataSources;
using Domain.Dto.Requests;
using Domain.Models;
using Domain.Repositories;

namespace Infraestructure.Repositories;

public class AuthRepository(IAuthDataSource dataSource): IAuthRepository
{
    
    public Task<User> Register(CreateUserDto user)
    {
        return dataSource.Register(user);
    }

    public Task<User> Login(LoginDto user)
    {
        return dataSource.Login(user);
    }
}