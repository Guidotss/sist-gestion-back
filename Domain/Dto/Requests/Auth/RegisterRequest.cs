using Domain.Dto.Responses;
using MediatR;

namespace Domain.Dto.Requests.Auth;

public class RegisterRequest(CreateUserDto createUserDto) : IRequest<AuthResponse>
{
    public CreateUserDto RegisterDto { get; set; } = createUserDto;
}