using api.Employee.Model;
using api.utils;

namespace api.Employee.Repository;

public interface IEmployeeRepository
{
    Task<(List<EmployeeModel>, int)> GetEmployees(PaginationParams paginationParams, string? search, EmployeeFilters? filters);

    Task<EmployeeModel?> GetEmployee(int id);
    Task<EmployeeModel> CreateEmployee(EmployeeModel employee);
    Task<EmployeeModel> UpdateEmployee(EmployeeModel employee);
    Task LockEmployeeForModification(EmployeeModel employee, string lockedBy);
    Task<bool> IsEmployeeLockedByAnotherAdmin(int id, string lockedBy);
    Task UnlockEmployeeForModification(int id);
    Task<bool> DeleteEmployee(int id);
    Task<int> EmployeeCount();

    void Detach(EmployeeModel employee);
}