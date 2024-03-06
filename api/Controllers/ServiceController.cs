using api.Services;
using Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/v1/[controller]s")]
public class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetServices()
    {
        var services = await _serviceService.GetServices();
        return Ok(services);
    }

    [HttpPost]
    public async Task<IActionResult> CreateService([FromBody] CreateServiceDto createServiceDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var service = await _serviceService.CreateService(createServiceDto);
        return CreatedAtAction(nameof(GetService), new { id = service.Id }, service);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetService(int id)
    {
        var service = await _serviceService.GetService(id);
        return Ok(service);
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateService(int id, [FromBody] UpdateServiceDto updateServiceDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (id != updateServiceDto.Id)
            return BadRequest("Id in the body does not match the id in the route");

        var service = await _serviceService.UpdateService(updateServiceDto);
        return Ok(service);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteService(int id)
    {
        await _serviceService.DeleteService(id);
        return Ok();
    }


}