using api.database;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class SiteRepository : ISiteRepository
{
    private readonly ApplicationContext _context;

    public SiteRepository(ApplicationContext context)
    {
        _context = context;
    }



    public Task<List<Site>> GetSites()
    {
        return _context.Sites.ToListAsync();
    }

    public async Task<Site> CreateSite(Site site)
    {
        var siteCreated = await _context.Sites.AddAsync(site);
        await _context.SaveChangesAsync();
        return siteCreated.Entity;
    }

    public Task<Site?> GetSite(int id)
    {
        return _context.Sites.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Site> UpdateSite(Site site)
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

}