using CarManageSystem.Domain.Entities;
using CarManageSystem.Domain.Repositories;
using CarManageSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarManageSystem.Infrastructure.Repositories;

internal class CarInfosRepository(CarDbContext dbContext) : ICarInfoRepository
{
    public async Task<IEnumerable<CarInfo>> GetAllAsync()
    {
        var carInfos = await dbContext.CarsInfo.ToListAsync();
        return carInfos;
    }

    public async Task<IEnumerable<CarInfo>> GetByCarIdAsync(int carId)
    {
        var carInfos = await dbContext.CarsInfo.Where(car => car.CarId == carId).ToListAsync();
        return carInfos;
    }

    public async Task<CarInfo?> GetByIdAsync(int id)
    {
        var carInfo = await dbContext.CarsInfo.FirstOrDefaultAsync(car => car.Id == id);
        return carInfo;
    }

    public async Task<int> CreateAsync(CarInfo carInfo)
    {
        dbContext.CarsInfo.Add(carInfo);
        await dbContext.SaveChangesAsync();
        return carInfo.Id;
    }

    public async Task DeleteAsync(int id)
    {
        var carInfo = await dbContext.CarsInfo.FirstOrDefaultAsync(car => car.Id == id);
        if (carInfo is not null)
        {
            dbContext.CarsInfo.Remove(carInfo);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(int id, CarInfo car)
    {
        var carInfo = await dbContext.CarsInfo.FirstOrDefaultAsync(car => car.Id == id);
        if (carInfo is not null)
        {
            carInfo.CarId = car.CarId;
            carInfo.InspectionDate = car.InspectionDate;
            carInfo.InsuranceDate = car.InsuranceDate;
            carInfo.OilChangeDate = car.OilChangeDate;
            carInfo.TireChangeDate = car.TireChangeDate;
            await dbContext.SaveChangesAsync();
        }
    }
}