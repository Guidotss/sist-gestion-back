using Domain.Models;

namespace Domain.Dto.Responses;

public class AuthResponse
{
    public string Token { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public User User { get; set; }
}