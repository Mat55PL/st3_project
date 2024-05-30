using CarManageSystem.Application.CarsInfo.Dtos;
using CarManageSystem.Domain.Entities;
using CarManageSystem.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CarManageSystem.Application.CarsInfo;

public class CarsInfoService(ICarInfoRepository carInfoRepository, ILogger<CarsInfoService> logger) : ICarsInfoService
{
    public async Task<IEnumerable<CarInfo>> GetAllCarsInfoAsync()
    {
        logger.LogInformation("Getting all cars info");
        var carsInfo = await carInfoRepository.GetAllAsync();
        return carsInfo;
    }

    public async Task<CarInfo?> GetCarInfoByIdAsync(int id)
    {
        logger.LogInformation("Getting car info by id {id}", id);
        var carInfo = await carInfoRepository.GetByIdAsync(id);
        return carInfo;
    }
    
    public async Task<IEnumerable<CarInfo>> GetCarInfoByCarIdAsync(int carId)
    {
        logger.LogInformation("Getting car info by car id {carId}", carId);
        var carInfo = await carInfoRepository.GetByCarIdAsync(carId);
        return carInfo;
    }

    public async Task DeleteCarInfoAsync(int id)
    {
        logger.LogInformation("Deleting car info by id {id}", id);
        await carInfoRepository.DeleteAsync(id);
    }

    public async Task UpdateCarInfoAsync(int id, CarInfoDto carInfoDto)
    {
        logger.LogInformation("Updating car info by id {id}", id);
        var carInfo = new CarInfo
        {
            Id = id,
            CarId = carInfoDto.CarId,
            InspectionDate = carInfoDto.InspectionDate,
            InsuranceDate = carInfoDto.InsuranceDate,
            OilChangeDate = carInfoDto.OilChangeDate,
            TireChangeDate = carInfoDto.TireChangeDate
        };
        await carInfoRepository.UpdateAsync(id, carInfo);
    }

    public async Task<int> CreateCarInfoAsync(CreateCarInfoDto carInfoDto)
    {
        logger.LogInformation("Creating car info");
        var carInfo = new CarInfo
        {
            CarId = carInfoDto.CarId,
            InspectionDate = carInfoDto.InspectionDate,
            InsuranceDate = carInfoDto.InsuranceDate,
            OilChangeDate = carInfoDto.OilChangeDate,
            TireChangeDate = carInfoDto.TireChangeDate
        };
        var createdCarInfoId = await carInfoRepository.CreateAsync(carInfo);
        return createdCarInfoId;
    }

  
}