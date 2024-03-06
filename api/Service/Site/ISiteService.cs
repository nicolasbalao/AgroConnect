using Contracts.Dtos;

namespace api.Services;

public interface ISiteService
{
    Task<List<SiteDto>> GetSites();
    Task<SiteDto> GetSite(int id);
    Task<SiteDto> CreateSite(CreateSiteDto createSiteDto);
    Task<SiteDto> UpdateSite(UpdateSiteDto updateSiteDto);
    Task DeleteSite(int id);
}