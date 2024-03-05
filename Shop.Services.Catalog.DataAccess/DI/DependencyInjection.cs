using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Services.Catalog.DataAccess.Abstractions;
using Shop.Services.Catalog.DataAccess.Common;
using Shop.Services.Catalog.DataAccess.Constants;
using Shop.Services.Catalog.DataAccess.Context;
using Shop.Services.Catalog.DataAccess.Repositories;

namespace Shop.Services.Catalog.DataAccess.DI;

public static class DependencyInjection
{
    public static void AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString(DataAccessConstants.DbConnection));
            opt.EnableSensitiveDataLogging();
            opt.AddInterceptors(new EntityDateTrackingInterceptor());
        });

        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}