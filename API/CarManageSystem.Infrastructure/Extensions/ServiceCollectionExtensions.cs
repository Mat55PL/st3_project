using CarManageSystem.Domain.Repositories;
using CarManageSystem.Infrastructure.Persistence;
using CarManageSystem.Infrastructure.Repositories;
using CarManageSystem.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarManageSystem.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CarsDbConnection");
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        services.AddDbContext<CarDbContext>(options => options.UseMySql(connectionString, serverVersion));
        
        services.AddScoped<ICarSeeder, CarSeeder>();
        services.AddScoped<ICarsRepository, CarsRepository>();
        services.AddScoped<IFuelHistoryRepository, FuelHistoryRepository>();
        services.AddScoped<ICarInfoRepository, CarInfosRepository>();
    }
}