using CarManageSystem.Application.Cars;
using CarManageSystem.Application.CarsFuelHistory;
using CarManageSystem.Application.CarsInfo;
using Microsoft.Extensions.DependencyInjection;

namespace CarManageSystem.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICarsService, CarsService>();
        services.AddScoped<ICarsInfoService, CarsInfoService>();
        services.AddScoped<ICarsFuelHistoryService, CarsFuelHistoryService>();
    }
}