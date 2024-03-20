using api.Site.Model;

namespace api.Site.Repository
{
    public interface ISiteRepository
    {
        Task<List<SiteModel>> GetSites();
        Task<SiteModel?> GetSite(int id);
        Task<SiteModel> CreateSite(SiteModel site);
        Task<SiteModel> UpdateSite(SiteModel site);
        Task<bool> DeleteSite(int id);
        Task<bool> SiteHaveEmployees(int id);
        Task<bool> SiteExists(int id);
    }
}