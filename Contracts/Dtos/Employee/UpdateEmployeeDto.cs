using Contracts.Dtos.Employee;

namespace Contracts.Dtos;

public class UpdateEmployeeDto : CreateEmployeeDto
{
    public int Id { get; set; }
}