using api.Model;
using Contracts.Dtos;

namespace api.Mappers;

public static class ServiceMapper
{
    public static DepartmentDto ToDto(this Department department) => new DepartmentDto
    {
        Id = department.Id,
        Name = department.Name
    };

    public static Department ToDepartment(this CreateDepartmentDto createDepartmentDto) => new Department
    {
        Name = createDepartmentDto.Name
    };

    public static Department ToDepartment(this UpdateDepartmentDto updateDepartmentDto) => new Department
    {
        Id = updateDepartmentDto.Id,
        Name = updateDepartmentDto.Name
    };
}