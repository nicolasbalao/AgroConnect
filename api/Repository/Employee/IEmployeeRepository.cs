using api.Model;

namespace api.Repository;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetEmployees();
    Task<Employee?> GetEmployee(int id);
    Task<Employee> CreateEmployee(Employee employee);
    Task<Employee> UpdateEmployee(Employee employee);
    Task<bool> DeleteEmployee(int id);
}