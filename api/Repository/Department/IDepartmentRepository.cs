using api.Department.Model;

namespace api.Department.Repository;

public interface IDepartmentRepository
{
    Task<List<DepartmentModel>> GetDepartment();
    Task<DepartmentModel?> GetDepartment(int id);
    Task<DepartmentModel> CreateDepartment(DepartmentModel department);
    Task<DepartmentModel> UpdateDepartment(DepartmentModel department);
    Task<bool> DeleteDepartment(int id);
    Task<bool> DepartmentHaveEmployees(int id);

    Task<bool> DepartmentExists(int id);
}