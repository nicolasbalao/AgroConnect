using api.Model;
using Contracts.Dtos;

namespace api.Services;

public interface IServiceService
{
    Task<List<ServiceDto>> GetServices();
    Task<ServiceDto> CreateService(CreateServiceDto createServiceDto);

    Task<ServiceDto> GetService(int id);
    Task<ServiceDto> UpdateService(UpdateServiceDto updateServiceDto);
    Task DeleteService(int id);
}
