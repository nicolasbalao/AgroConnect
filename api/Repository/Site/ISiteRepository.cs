using api.Model;

namespace api.Repository
{
    public interface ISiteRepository
    {
        Task<List<Site>> GetSites();
        Task<Site?> GetSite(int id);
        Task<Site> CreateSite(Site site);
        Task<Site> UpdateSite(Site site);
        Task<bool> DeleteSite(int id);
        Task<bool> SiteHaveEmployees(int id);
    }
}