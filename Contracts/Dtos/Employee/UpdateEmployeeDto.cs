
using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos;

public class UpdateEmployeeDto : CreateEmployeeDto
{
    [Required]
    public int Id { get; set; }
}