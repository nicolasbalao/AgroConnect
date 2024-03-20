using api.Infrastructure.Database;
using api.Site.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Site.Repository;

public class SiteRepository : ISiteRepository
{
    private readonly ApplicationContext _context;

    public SiteRepository(ApplicationContext context)
    {
        _context = context;
    }



    public Task<List<SiteModel>> GetSites()
    {
        return _context.Sites.ToListAsync();
    }

    public async Task<SiteModel> CreateSite(SiteModel site)
    {
        var siteCreated = await _context.Sites.AddAsync(site);
        await _context.SaveChangesAsync();
        return siteCreated.Entity;
    }

    public Task<SiteModel?> GetSite(int id)
    {
        return _context.Sites.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<SiteModel> UpdateSite(SiteModel site)
    {
        var updatedSite = _context.Sites.Update(site);
        await _context.SaveChangesAsync();
        return updatedSite.Entity;
    }

    public async Task<bool> DeleteSite(int id)
    {
        var site = await _context.Sites.FirstOrDefaultAsync(x => x.Id == id);
        if (site == null)
        {

            return false;

        }
        _context.Sites.Remove(site);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> SiteHaveEmployees(int id)
    {
        return await _context.Employees.AnyAsync(x => x.SiteId == id);
    }

    public Task<bool> SiteExists(int id)
    {
        return _context.Sites.AnyAsync(x => x.Id == id);
    }

}