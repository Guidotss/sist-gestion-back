using Domain.Dto.Requests;
using Domain.Dto.Requests.Auth;
using Domain.Dto.Responses;
using Domain.Repositories;
using Domain.Services;
using MediatR;

namespace Domain.UseCases.Implementations;

public class RegisterUserUseCase(IAuthRepository _authRepository, IJwtService _jwtService) : IRequestHandler<RegisterRequest, AuthResponse>
{
    public async Task<AuthResponse> Handle(RegisterRequest registerRequest, CancellationToken cancellationToken)
    {
        var newUser = await _authRepository.Register(registerRequest.RegisterDto);
        string token = _jwtService.GenerateToken(newUser.Id, newUser.Email);
        var response = new AuthResponse
        {
            Ok = true,
            Message = "User registered successfully",
            User = newUser,
            Token = token, 
        };

        return response; 
    }
}