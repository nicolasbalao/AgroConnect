using System.ComponentModel;
using api.CustomException;
using api.Decorators;
using api.Mappers;
using api.Model;
using api.Repository;
using Contracts.Dtos;

namespace api.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ISiteRepository _siteRepository;

    private readonly IDepartmentRepository _departmentRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, ISiteRepository siteRepository, IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _siteRepository = siteRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task<PaginatedResponse<EmployeeDto>> GetEmployees(PaginationParams paginationParams, string? search)
    {
        List<Employee> employees;

        if (search is null)
            employees = await _employeeRepository.GetEmployees(paginationParams);
        else
            employees = await _employeeRepository.GetEmployees(paginationParams, search);

        int TotalItems = await _employeeRepository.EmployeeCount();

        return new PaginatedResponse<EmployeeDto>
        {
            Items = employees.Select(e => e.ToDto()).ToList(),
            TotalItems = TotalItems,
            Page = paginationParams.Page,
            Size = paginationParams.Size
        };


    }

    public async Task<EmployeeDto> GetEmployee(int id)
    {
        var employee = await _employeeRepository.GetEmployee(id);
        if (employee is null)
            throw new NotFoundExecption("Employee not found");
        return employee.ToDto();
    }

    public async Task<EmployeeDto> CreateEmployee(CreateEmployeeDto createEmployeeDto)
    {

        await HandleRelationExist(createEmployeeDto);

        var employee = createEmployeeDto.ToEmployee();

        var createdEmployee = await _employeeRepository.CreateEmployee(employee);
        return createdEmployee.ToDto();
    }



    public async Task<EmployeeDto> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
    {

        await EnsureEmployeeModifiability(updateEmployeeDto.Id);
        await HandleRelationExist(updateEmployeeDto);

        var employee = updateEmployeeDto.ToEmployee();
        var updatedEmployee = await _employeeRepository.UpdateEmployee(employee);

        await _employeeRepository.UnlockEmployeeForModification(updateEmployeeDto.Id);

        return updatedEmployee.ToDto();
    }

    private async Task EnsureEmployeeModifiability(int id)
    {
        var isLocked = await _employeeRepository.IsEmployeeLockedForModification(id);

        if (isLocked)
            throw new BadRequestException("Employee is locked for modification");
    }

    private async Task HandleRelationExist(CreateEmployeeDto createEmployeeDto)
    {
        if (!await _siteRepository.SiteExists(createEmployeeDto.SiteId))
            throw new NotFoundExecption("Site not found");

        if (!await _departmentRepository.DepartmentExists(createEmployeeDto.DepartmentId))
            throw new NotFoundExecption("Department not found");
    }

    public async Task DeleteEmployee(int id)
    {
        var isDeleted = await _employeeRepository.DeleteEmployee(id);
        if (isDeleted == false)
            throw new NotFoundExecption("Employee not found");

    }

    public async Task LockEmployeeForModification(int id, string lockedBy)
    {
        var employee = await _employeeRepository.GetEmployee(id);

        if (employee is null)
            throw new NotFoundExecption("Employee not found");

        if (employee.IsLocked)
            throw new BadRequestException("Employee is already locked for modification");

        // TODO: If throw new is like return
        await _employeeRepository.LockEmployeeForModification(employee, lockedBy);
    }
}