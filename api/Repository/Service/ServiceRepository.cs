using api.database;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class ServiceRepository : IServiceRepository
{
    private readonly ApplicationContext _context;

    public ServiceRepository(ApplicationContext context)
    {
        _context = context;
    }

    public Task<List<Service>> GetServices()
    {
        return _context.Services.ToListAsync();
    }



    public async Task<Service> CreateService(Service service)
    {
        var serviceCreated = await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();
        return serviceCreated.Entity;
    }

    public async Task<Service?> GetService(int id)
    {
        return await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Service> UpdateService(Service service)
    {
        var updatedService = _context.Services.Update(service);
        await _context.SaveChangesAsync();
        return updatedService.Entity;
    }

    public async Task<bool> DeleteService(int id)
    {
        var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);
        if (service == null)
        {
            return false;
        }
        _context.Services.Remove(service);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ServiceHaveEmployees(int id)
    {
        return await _context.Employees.AnyAsync(x => x.ServiceId == id);
    }
}