using api.Model;
using api.utils;

namespace api.Repository;

public interface IEmployeeRepository
{
    Task<(List<Employee>, int)> GetEmployees(PaginationParams paginationParams, string? search, EmployeeFilters? filters);

    Task<Employee?> GetEmployee(int id);
    Task<Employee> CreateEmployee(Employee employee);
    Task<Employee> UpdateEmployee(Employee employee);
    Task LockEmployeeForModification(Employee employee, string lockedBy);
    Task<bool> IsEmployeeLockedByAnotherAdmin(int id, string lockedBy);
    Task UnlockEmployeeForModification(int id);
    Task<bool> DeleteEmployee(int id);
    Task<int> EmployeeCount();

    void Detach(Employee employee);
}