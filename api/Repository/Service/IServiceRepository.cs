using api.Model;

namespace api.Repository;

public interface IServiceRepository
{
    Task<List<Service>> GetServices();
    Task<Service?> GetService(int id);
    Task<Service> CreateService(Service service);
    Task<Service> UpdateService(Service service);
    Task<bool> DeleteService(int id);
    Task<bool> ServiceHaveEmployees(int id);
}