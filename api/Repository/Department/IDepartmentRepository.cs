using api.Model;

namespace api.Repository;

public interface IDepartmentRepository
{
    Task<List<Department>> GetDepartment();
    Task<Department?> GetDepartment(int id);
    Task<Department> CreateDepartment(Department department);
    Task<Department> UpdateDepartment(Department department);
    Task<bool> DeleteDepartment(int id);
    Task<bool> DepartmentHaveEmployees(int id);

    Task<bool> DepartmentExists(int id);
}