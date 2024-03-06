using api.CustomException;
using api.Repository;
using Contracts.Dtos;
using api.Mappers;

namespace api.Services;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceService(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<List<ServiceDto>> GetServices()
    {
        var sites = await _serviceRepository.GetServices();
        return sites.Select(site => site.ToDto()).ToList();
    }
    public Task<ServiceDto> CreateService(CreateServiceDto createServiceDto)
    {
        var site = createServiceDto.ToService();
        return _serviceRepository.CreateService(site).ContinueWith(task => task.Result.ToDto());
    }

    public async Task<ServiceDto> GetService(int id)
    {
        var site = await _serviceRepository.GetService(id);
        if (site == null)
        {
            throw new NotFoundExecption("Department not found");

        }
        return site.ToDto();
    }
    public async Task<ServiceDto> UpdateService(UpdateServiceDto updateServiceDto)
    {
        var updatedSite = await _serviceRepository.UpdateService(updateServiceDto.ToService());
        return updatedSite.ToDto();
    }


    public async Task DeleteService(int id)
    {
        if (await _serviceRepository.ServiceHaveEmployees(id))
        {
            throw new BadRequestException("Department have employees");
        }
        var isDeleted = await _serviceRepository.DeleteService(id);
        if (isDeleted == false)
        {
            throw new NotFoundExecption("Department not found");
        }
    }


}