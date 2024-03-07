using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos;
public class CreateDepartmentDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
}