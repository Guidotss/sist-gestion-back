namespace Domain.Dto.Responses;

public class GetAllResponseDto<T>
{
    public bool Success { get; set; }
    public IEnumerable<T> Data { get; set; }
    public int Total { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}