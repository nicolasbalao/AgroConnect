using System.ComponentModel.DataAnnotations;

namespace api.utils;

public class PaginationParams
{
    [Range(1, int.MaxValue, ErrorMessage = "Page must be a positive integer.")]
    public int Page { get; set; } = 1;

    [Range(1, 100, ErrorMessage = "Size must be a positive integer.")]
    public int Size { get; set; } = 10;

    public int GetLimit()
    {
        return Size;
    }

    public int GetOffset()
    {
        return (Page - 1) * Size;
    }


}

