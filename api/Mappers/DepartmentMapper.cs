using api.Department.Model;
using Contracts.Dtos;

namespace api.Department.Mapper;

public static class ServiceMapper
{
    public static DepartmentDto ToDto(this DepartmentModel department) => new DepartmentDto
    {
        Id = department.Id,
        Name = department.Name
    };

    public static DepartmentModel ToDepartment(this CreateDepartmentDto createDepartmentDto) => new DepartmentModel
    {
        Name = createDepartmentDto.Name
    };

    public static DepartmentModel ToDepartment(this UpdateDepartmentDto updateDepartmentDto) => new DepartmentModel
    {
        Id = updateDepartmentDto.Id,
        Name = updateDepartmentDto.Name
    };
}