namespace Domain.Dto.Responses;

public class CreateResponseDto<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
}