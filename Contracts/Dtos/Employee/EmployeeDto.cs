namespace Contracts.Dtos;

public class EmployeeDto
{

    public int Id { get; set; }
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;

    public string HomePhone { get; set; } = string.Empty;

    public string CellPhone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DepartmentDto Department { get; set; } = new DepartmentDto();

    public SiteDto Site { get; set; } = new SiteDto();
}