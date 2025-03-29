using Domain.Dto.Requests;
using Domain.Models;

namespace Domain.Repositories;

public interface IAuthRepository
{
    Task<User> Register(CreateUserDto user);
    Task<User> Login(LoginDto user);
}