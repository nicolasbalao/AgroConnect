using api.Model;
using Contracts.Dtos;
namespace api.Mappers;

public static class SiteMapper
{

    public static SiteDto ToDto(this Site site)
    {
        return new SiteDto
        {
            Id = site.Id,
            City = site.City
        };
    }

    public static Site ToSite(this CreateSiteDto createSiteDto)
    {
        return new Site
        {
            City = createSiteDto.City
        };
    }

    public static Site ToSite(this UpdateSiteDto updateSiteDto)
    {
        return new Site
        {
            Id = updateSiteDto.Id,
            City = updateSiteDto.City
        };
    }

}