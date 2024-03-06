using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos;
public class CreateServiceDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
}