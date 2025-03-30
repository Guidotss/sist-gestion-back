using System.Security.Claims;

namespace Domain.Services;

public interface IJwtService
{
    public string GenerateToken(Guid userId, string email);
    public ClaimsPrincipal ValidateToken(string token); 
}