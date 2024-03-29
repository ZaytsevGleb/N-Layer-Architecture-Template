using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Services.Catalog.BusinessLogic.Abstractions;
using Shop.Services.Catalog.BusinessLogic.Mappers;
using Shop.Services.Catalog.DataAccess.DI;
using Shop.Services.Catalog.ExternalService.DI;

namespace Shop.Services.Catalog.BusinessLogic.DI;

public static class DependencyInjection
{
    public static void AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataAccessDependencies(configuration);
        services.AddExternalServiceDependencies(configuration);
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddScoped<IService, Service>();
    }
}