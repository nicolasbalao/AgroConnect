using api.Decorators;
using Contracts.Dtos;

namespace api.Services
{
    public interface IEmployeeService
    {
        Task<PaginatedResponse<EmployeeDto>> GetEmployees(PaginationParams paginationParams, string? search);
        Task<EmployeeDto> GetEmployee(int id);
        Task<EmployeeDto> CreateEmployee(CreateEmployeeDto createEmployeeDto);
        Task<EmployeeDto> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);
        Task LockEmployeeForModification(int id, string lockedBy);
        Task DeleteEmployee(int id);
    }
}