using Contracts.Dtos;

namespace api.Services;

public interface IDepartmentService
{
    Task<List<DepartmentDto>> GetDepartments();
    Task<DepartmentDto> CreateDepartment(CreateDepartmentDto createDepartmentDto);

    Task<DepartmentDto> GetDepartment(int id);
    Task<DepartmentDto> UpdateService(UpdateDepartmentDto updateDepartmentDto);
    Task DeleteDepartment(int id);
}
