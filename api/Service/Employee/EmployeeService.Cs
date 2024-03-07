using System.ComponentModel;
using api.CustomException;
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

    public async Task<List<EmployeeDto>> GetEmployees(string? search)
    {
        var employees = await _employeeRepository.GetEmployees(search);
        return employees.Select(e => e.ToDto()).ToList();

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

        await HandleRelationExist(updateEmployeeDto);
        var employee = updateEmployeeDto.ToEmployee();
        var updatedEmployee = await _employeeRepository.UpdateEmployee(employee);
        return updatedEmployee.ToDto();
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

}