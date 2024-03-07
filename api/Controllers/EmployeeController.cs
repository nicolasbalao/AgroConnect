
using api.Services;
using Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

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
    public async Task<ActionResult<List<EmployeeDto>>> GetEmployees([FromQuery] string? search = null)
    {
        return await _employeeService.GetEmployees(search);
    }

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

    [HttpPut("{id:int}")]
    public async Task<ActionResult<EmployeeDto>> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (id != updateEmployeeDto.Id)
            return BadRequest("Id in the body does not match the id in the route");

        return await _employeeService.UpdateEmployee(updateEmployeeDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        await _employeeService.DeleteEmployee(id);
        return Ok();
    }

}
