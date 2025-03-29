namespace Domain.Exceptions;

public class CustomException(string message, int statusCode): System.Exception
{
    public string Message { get; set; } = message;
    public int StatusCode { get; set; } = statusCode;
}