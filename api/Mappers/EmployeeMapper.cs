using api.Model;
using Contracts.Dtos;

namespace api.Mappers;

public static class EmployeeMapper
{

    public static EmployeeDto MapEmployeeToEmployeeDto(Employee employee)
    {
        return new EmployeeDto
        {
            Firstname = employee.Firstname,
            Lastname = employee.Lastname,
            HomePhone = employee.HomePhone,
            CellPhone = employee.CellPhone,
            Email = employee.Email,
            Department = employee.Department.ToDto(),
            Site = employee.Site.ToDto()
        };
    }

    public static Employee MapCreateEmployeeDtoToEmployee(CreateEmployeeDto createEmployeeDto)
    {
        return new Employee
        {
            Firstname = createEmployeeDto.Firstname,
            Lastname = createEmployeeDto.Lastname,
            HomePhone = createEmployeeDto.HomePhone,
            CellPhone = createEmployeeDto.CellPhone,
            Email = createEmployeeDto.Email,
            DepartmentId = createEmployeeDto.DepartmentId,
            SiteId = createEmployeeDto.SiteId
        };
    }



}