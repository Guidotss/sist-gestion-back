using Domain.Dto.Responses;
using MediatR;

namespace Domain.Dto.Requests.Auth;

public class LoginRequest(LoginDto loginDto) : IRequest<AuthResponse>
{
    public LoginDto LoginDto { get; set; } = loginDto;
}

