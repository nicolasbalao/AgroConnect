using api.Repository;
using api.Mappers;
using Contracts.Dtos;
using api.CustomException;

namespace api.Services;

public class SiteService : ISiteService
{

    private readonly ISiteRepository _siteRepository;

    public SiteService(ISiteRepository siteRepository)
    {
        _siteRepository = siteRepository;
    }

    public async Task<List<SiteDto>> GetSites()
    {
        var sites = await _siteRepository.GetSites();
        return sites.Select(site => site.ToDto()).ToList();
    }
    public Task<SiteDto> CreateSite(CreateSiteDto createSiteDto)
    {
        var site = createSiteDto.ToSite();
        return _siteRepository.CreateSite(site).ContinueWith(task => task.Result.ToDto());
    }

    public async Task<SiteDto> GetSite(int id)
    {
        var site = await _siteRepository.GetSite(id);
        if (site == null)
        {
            throw new NotFoundExecption("Site not found");

        }
        return site.ToDto();
    }
    public async Task<SiteDto> UpdateSite(UpdateSiteDto updateSiteDto)
    {
        var updatedSite = await _siteRepository.UpdateSite(updateSiteDto.ToSite());
        return updatedSite.ToDto();
    }


    public async Task DeleteSite(int id)
    {
        if (await _siteRepository.SiteHaveEmployees(id))
        {
            throw new BadRequestException("Site have employees");
        }
        var isDeleted = await _siteRepository.DeleteSite(id);
        if (isDeleted == false)
        {
            throw new NotFoundExecption("Site not found");
        }
    }

}