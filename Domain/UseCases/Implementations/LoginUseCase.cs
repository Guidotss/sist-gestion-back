using Domain.Dto.Requests;
using Domain.Dto.Requests.Auth;
using Domain.Dto.Responses;
using Domain.Repositories;
using Domain.Services;
using MediatR;

namespace Domain.UseCases.Implementations;

public class LoginUseCase(IAuthRepository authRepository, IJwtService jwtService)
    : IRequestHandler<LoginRequest, AuthResponse>
{
    public async Task<AuthResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await authRepository.Login(request.LoginDto);
        var token = jwtService.GenerateToken(user.Id, user.Email);
                
        var response = new AuthResponse
        {
            Ok = true,
            Message = "User logged in successfully",
            User = user,
            Token = token
        };
        return response; 
    }
}