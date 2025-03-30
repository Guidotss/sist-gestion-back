using Domain.Models;

namespace Domain.Dto.Responses;

public class AuthResponse
{
    public bool Ok { get; set; }
    public string Token { get; set; }
    public string Message { get; set; }
    public User User { get; set; }
}