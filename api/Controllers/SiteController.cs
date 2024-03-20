using api.Admin.Filters;
using api.Site.Service;
using Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace api.Site.Controller;

[ApiController]
[Route("api/v1/[controller]s")]
public class SiteController : ControllerBase
{

    private readonly ISiteService _siteService;

    public SiteController(ISiteService siteService)
    {
        _siteService = siteService;
    }

    [HttpGet]
    public async Task<ActionResult<List<SiteDto>>> GetSites()
    {
        return await _siteService.GetSites();
    }


    [ServiceFilter(typeof(AdminAuthorize))]
    [HttpPost]
    public async Task<ActionResult<SiteDto>> CreateSite([FromBody] CreateSiteDto createSiteDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var serviceCreated = await _siteService.CreateSite(createSiteDto);
        return CreatedAtAction(nameof(GetSite), new { id = serviceCreated.Id }, serviceCreated);
    }


    [ServiceFilter(typeof(AdminAuthorize))]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<SiteDto>> GetSite(int id)
    {
        return await _siteService.GetSite(id);
    }


    [ServiceFilter(typeof(AdminAuthorize))]
    [HttpPut("{id:int}")]
    public async Task<ActionResult<SiteDto>> UpdateSite(int id, [FromBody] UpdateSiteDto updateSiteDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (id != updateSiteDto.Id)
            return BadRequest("Id in the body does not match the id in the route");

        return await _siteService.UpdateSite(updateSiteDto);
    }

    [ServiceFilter(typeof(AdminAuthorize))]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteSite(int id)
    {
        await _siteService.DeleteSite(id);
        return Ok();
    }
}