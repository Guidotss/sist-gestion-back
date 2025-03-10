namespace Domain.Dto.Requests;

public class CreateUserDto
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
}