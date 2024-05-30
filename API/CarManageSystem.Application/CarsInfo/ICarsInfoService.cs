using CarManageSystem.Application.CarsInfo.Dtos;
using CarManageSystem.Domain.Entities;

namespace CarManageSystem.Application.CarsInfo;

public interface ICarsInfoService
{
    Task<IEnumerable<CarInfo>> GetAllCarsInfoAsync();
    Task<CarInfo?> GetCarInfoByIdAsync(int id);
    Task<int> CreateCarInfoAsync(CreateCarInfoDto carInfoDto);
    Task<IEnumerable<CarInfo>> GetCarInfoByCarIdAsync(int carId);
    Task DeleteCarInfoAsync(int id);
    Task UpdateCarInfoAsync(int id, CarInfoDto carInfoDto);
}