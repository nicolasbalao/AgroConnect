using api.CustomException;
using api.Repository;
using Contracts.Dtos;
using api.Mappers;

namespace api.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _serviceRepository;

    public DepartmentService(IDepartmentRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    public async Task<List<DepartmentDto>> GetDepartments()
    {
        var sites = await _serviceRepository.GetDepartment();
        return sites.Select(site => site.ToDto()).ToList();
    }
    public Task<DepartmentDto> CreateDepartment(CreateDepartmentDto createServiceDto)
    {
        var site = createServiceDto.ToDepartment();
        return _serviceRepository.CreateDepartment(site).ContinueWith(task => task.Result.ToDto());
    }

    public async Task<DepartmentDto> GetDepartment(int id)
    {
        var site = await _serviceRepository.GetDepartment(id);
        if (site == null)
        {
            throw new NotFoundExecption("Department not found");

        }
        return site.ToDto();
    }
    public async Task<DepartmentDto> UpdateService(UpdateDepartmentDto updateServiceDto)
    {
        var updatedSite = await _serviceRepository.UpdateDepartment(updateServiceDto.ToDepartment());
        return updatedSite.ToDto();
    }


    public async Task DeleteDepartment(int id)
    {
        if (await _serviceRepository.DepartmentHaveEmployees(id))
        {
            throw new BadRequestException("Department have employees");
        }
        var isDeleted = await _serviceRepository.DeleteDepartment(id);
        if (isDeleted == false)
        {
            throw new NotFoundExecption("Department not found");
        }
    }


}