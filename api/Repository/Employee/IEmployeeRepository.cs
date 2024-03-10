using api.Decorators;
using api.Model;

namespace api.Repository;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetEmployees(PaginationParams paginationParams);
    Task<List<Employee>> GetEmployees(PaginationParams parginationParams, string search);
    Task<Employee?> GetEmployee(int id);
    Task<Employee> CreateEmployee(Employee employee);
    Task<Employee> UpdateEmployee(Employee employee);
    Task LockEmployeeForModification(Employee employee, string lockedBy);
    Task<bool> IsEmployeeLockedForModification(int id);
    Task<string> GetLockedBy(int id);
    Task UnlockEmployeeForModification(int id);
    Task<bool> DeleteEmployee(int id);
    Task<int> EmployeeCount();
}