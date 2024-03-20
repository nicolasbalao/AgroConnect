using api.Site.Model;
using Contracts.Dtos;
namespace api.Mappers;

public static class SiteMapper
{

    public static SiteDto ToDto(this SiteModel site)
    {
        return new SiteDto
        {
            Id = site.Id,
            City = site.City
        };
    }

    public static SiteModel ToSite(this CreateSiteDto createSiteDto)
    {
        return new SiteModel
        {
            City = createSiteDto.City
        };
    }

    public static SiteModel ToSite(this UpdateSiteDto updateSiteDto)
    {
        return new SiteModel
        {
            Id = updateSiteDto.Id,
            City = updateSiteDto.City
        };
    }

}