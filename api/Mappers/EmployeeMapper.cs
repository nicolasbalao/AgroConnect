using api.Department.Mapper;
using api.Employee.Model;
using api.Mappers;
using Contracts.Dtos;

namespace api.Employee.Mapper;

public static class EmployeeMapper
{

    public static EmployeeDto ToDto(this EmployeeModel employee)
    {
        return new EmployeeDto
        {
            Id = employee.Id,
            Firstname = employee.Firstname,
            Lastname = employee.Lastname,
            HomePhone = employee.HomePhone,
            CellPhone = employee.CellPhone,
            Email = employee.Email,
            IsLocked = employee.IsLocked,
            Department = employee.Department.ToDto(),
            Site = employee.Site.ToDto()
        };
    }

    public static EmployeeModel ToEmployee(this CreateEmployeeDto createEmployeeDto)
    {
        return new EmployeeModel
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

    public static EmployeeModel ToEmployee(this UpdateEmployeeDto updateEmployeeDto)
    {
        return new EmployeeModel
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