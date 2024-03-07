using System.ComponentModel.DataAnnotations;

namespace Contracts.Dtos;
public class CreateEmployeeDto
{
    [Required]
    public string Firstname { get; set; } = string.Empty;
    [Required]
    public string Lastname { get; set; } = string.Empty;

    public string HomePhone { get; set; } = string.Empty;
    [Required]
    public string CellPhone { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public int DepartmentId { get; set; }
    [Required]
    public int SiteId { get; set; }
}