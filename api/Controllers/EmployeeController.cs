
using api.Admin.Filters;
using api.Employee.Service;
using api.Framework.Exception;
using api.utils;
using Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace api.Employee.Controller;

[ApiController]
[Route("api/v1/[controller]s")]
public class EmployeeController : ControllerBase
{

    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


    [HttpGet]
    public async Task<ActionResult<PaginatedResponse<EmployeeDto>>> GetEmployees([FromQuery] PaginationParams paginationParams, [FromQuery] string? search, [FromQuery] EmployeeFilters? filters)
    {
        return await _employeeService.GetEmployees(paginationParams, search, filters);
    }

    [ServiceFilter(typeof(AdminAuthorize))]
    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> CreateEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdEmplyee = await _employeeService.CreateEmployee(createEmployeeDto);
        return CreatedAtAction(nameof(GetEmployee), new { id = createdEmplyee.Id }, createdEmplyee);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
    {
        return await _employeeService.GetEmployee(id);
    }

    [ServiceFilter(typeof(AdminAuthorize))]
    [HttpPut("{id:int}")]
    public async Task<ActionResult<EmployeeDto>> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (id != updateEmployeeDto.Id)
            return BadRequest("Id in the body does not match the id in the route");

        var userUid = GetUserUid();

        return await _employeeService.UpdateEmployee(updateEmployeeDto, userUid);
    }

    [ServiceFilter(typeof(AdminAuthorize))]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        await _employeeService.DeleteEmployee(id);
        return Ok();
    }

    [ServiceFilter(typeof(AdminAuthorize))]
    [HttpPut("{id:int}/lock")]
    public async Task<ActionResult> LockEmployeeForModification(int id)
    {

        var lockedBy = GetUserUid();
        await _employeeService.LockEmployeeForModification(id, lockedBy);
        return Ok();
    }

    [ServiceFilter(typeof(AdminAuthorize))]
    [HttpPut("{id:int}/lock/release")]
    public async Task<ActionResult> ReleaseEmployeeLock(int id)
    {

        var lockedBy = GetUserUid();
        await _employeeService.ReleaseEmployeeLock(id, lockedBy);
        return Ok();
    }
    private string GetUserUid()
    {
        if (!HttpContext.Items.TryGetValue("UserUid", out var uid))
        {
            throw new BadRequestException("User uid not found");
        }
        return uid.ToString();

    }


}
