using api.Model;
using Contracts.Dtos;
using Contracts.Dtos;

namespace api.Mappers;

public static class ServiceMapper
{
    public static ServiceDto ToDto(this Service service) => new ServiceDto
    {
        Id = service.Id,
        Name = service.Name
    };

    public static Service ToService(this CreateServiceDto createServiceDto) => new Service
    {
        Name = createServiceDto.Name
    };

    public static Service ToService(this UpdateServiceDto updateServiceDto) => new Service
    {
        Id = updateServiceDto.Id,
        Name = updateServiceDto.Name
    };
}