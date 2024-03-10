using api.Filters;
using api.Services;
using Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/v1/[controller]s")]
[ServiceFilter(typeof(AdminAuthorize))]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetDepartment()
    {
        var services = await _departmentService.GetDepartments();
        return Ok(services);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDto departmentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var service = await _departmentService.CreateDepartment(departmentDto);
        return CreatedAtAction(nameof(GetDepartment), new { id = service.Id }, service);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDepartment(int id)
    {
        var service = await _departmentService.GetDepartment(id);
        return Ok(service);
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentDto updateDepartmentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (id != updateDepartmentDto.Id)
            return BadRequest("Id in the body does not match the id in the route");

        var service = await _departmentService.UpdateService(updateDepartmentDto);
        return Ok(service);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        await _departmentService.DeleteDepartment(id);
        return Ok();
    }


}