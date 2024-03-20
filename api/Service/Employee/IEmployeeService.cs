using api.utils;
using Contracts.Dtos;

namespace api.Employee.Service
{
    public interface IEmployeeService
    {
        Task<PaginatedResponse<EmployeeDto>> GetEmployees(PaginationParams paginationParams, string? search, EmployeeFilters? filters);
        Task<EmployeeDto> GetEmployee(int id);
        Task<EmployeeDto> CreateEmployee(CreateEmployeeDto createEmployeeDto);
        Task<EmployeeDto> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto, string lockedBy);
        Task LockEmployeeForModification(int id, string lockedBy);
        Task DeleteEmployee(int id);
        Task ReleaseEmployeeLock(int id, string lockedBy);
    }
}