namespace Contracts.Dtos;
public class PaginatedResponse<T>
{
    public int TotalItems { get; set; }
    public List<T> Items { get; set; } = [];

    public int Page { get; set; }

    public int Size { get; set; }

}