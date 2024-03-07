using Contracts.Dtos;

namespace api.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetEmployees(string? search);
        Task<EmployeeDto> GetEmployee(int id);
        Task<EmployeeDto> CreateEmployee(CreateEmployeeDto createEmployeeDto);
        Task<EmployeeDto> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
        Task DeleteEmployee(int id);
    }
}