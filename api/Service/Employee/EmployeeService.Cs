using api.Department.Repository;
using api.Employee.Mapper;
using api.Employee.Model;
using api.Employee.Repository;
using api.Framework.Exception;
using api.Site.Repository;
using api.utils;
using Contracts.Dtos;

namespace api.Employee.Service;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ISiteRepository _siteRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IConfiguration _configuration;

    public EmployeeService(IEmployeeRepository employeeRepository, ISiteRepository siteRepository, IDepartmentRepository departmentRepository, IConfiguration configuration)
    {
        _employeeRepository = employeeRepository;
        _siteRepository = siteRepository;
        _departmentRepository = departmentRepository;
        _configuration = configuration;
    }

    public async Task<PaginatedResponse<EmployeeDto>> GetEmployees(PaginationParams paginationParams, string? search, EmployeeFilters? filters)
    {


        var employees = await _employeeRepository.GetEmployees(paginationParams, search, filters);

        int totalItems = await _employeeRepository.EmployeeCount();

        var employeeDtos = employees.Select(e => e.ToDto()).ToList();

        return new PaginatedResponse<EmployeeDto>
        {
            Items = employeeDtos,
            TotalItems = totalItems,
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



    public async Task<EmployeeDto> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto, string lockedBy)
    {

        if (await _employeeRepository.IsEmployeeLockedByAnotherAdmin(updateEmployeeDto.Id, lockedBy))
            throw new BadRequestException("Employee is locked by another admin");


        await HandleRelationExist(updateEmployeeDto);

        var employee = updateEmployeeDto.ToEmployee();
        var updatedEmployee = await _employeeRepository.UpdateEmployee(employee);

        await _employeeRepository.UnlockEmployeeForModification(updateEmployeeDto.Id);

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

    public async Task LockEmployeeForModification(int id, string lockedBy)
    {
        var employee = await _employeeRepository.GetEmployee(id);

        if (employee is null)
            throw new NotFoundExecption("Employee not found");


        if (employee.IsLocked && !IsPreviousLockExpired(employee))
            throw new ConflictException("Employee is already locked for modification");

        // TODO: If throw new is like return
        await _employeeRepository.LockEmployeeForModification(employee, lockedBy);
    }

    private bool IsPreviousLockExpired(EmployeeModel employee)
    {
        var lockTimeout = _configuration.GetSection("Env").GetValue<int>("LockTimeoutMinute");

        if (lockTimeout == 0)
            throw new BadRequestException("LockTimeoutMinute is not set");

        if (employee.LockedAt is null)
            return true;

        var employeeLockTime = employee.LockedAt.Value.AddMinutes(lockTimeout);

        if (employeeLockTime < DateTime.Now)
            return true;
        return false;
    }

    public async Task ReleaseEmployeeLock(int id, string lockedBy)
    {
        var employee = await _employeeRepository.GetEmployee(id);

        if (employee is null)
            throw new NotFoundExecption("Employee not found");
        if (employee.LockedBy != lockedBy)
            throw new BadRequestException("Employee is not locked by you");

        await _employeeRepository.UnlockEmployeeForModification(id);


    }
}