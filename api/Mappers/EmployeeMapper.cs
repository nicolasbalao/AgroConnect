using api.Model;
using Contracts.Dtos;

namespace api.Mappers;

public static class EmployeeMapper
{

    public static EmployeeDto ToDto(this Employee employee)
    {
        return new EmployeeDto
        {
            Id = employee.Id,
            Firstname = employee.Firstname,
            Lastname = employee.Lastname,
            HomePhone = employee.HomePhone,
            CellPhone = employee.CellPhone,
            Email = employee.Email,
            Department = employee.Department.ToDto(),
            Site = employee.Site.ToDto()
        };
    }

    public static Employee ToEmployee(this CreateEmployeeDto createEmployeeDto)
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

    public static Employee ToEmployee(this UpdateEmployeeDto updateEmployeeDto)
    {
        return new Employee
        {
            Id = updateEmployeeDto.Id,
            Firstname = updateEmployeeDto.Firstname,
            Lastname = updateEmployeeDto.Lastname,
            HomePhone = updateEmployeeDto.HomePhone,
            CellPhone = updateEmployeeDto.CellPhone,
            Email = updateEmployeeDto.Email,
            DepartmentId = updateEmployeeDto.DepartmentId,
            SiteId = updateEmployeeDto.SiteId
        };
    }



}