using CarManageSystem.Domain.Entities;
using CarManageSystem.Domain.Repositories;
using CarManageSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarManageSystem.Infrastructure.Repositories;

internal class FuelHistoryRepository(CarDbContext dbContext) : IFuelHistoryRepository
{
    public async Task<IEnumerable<FuelHistory>> GetAllAsync()
    {
        var fuelHistories = await dbContext.FuelHistories.ToListAsync();
        return fuelHistories;
    }

    public async Task<IEnumerable<FuelHistory>> GetByCarIdAsync(int carId)
    {
        var fuelHistories = await dbContext.FuelHistories.Where(x => x.CarId == carId).ToListAsync();
        return fuelHistories;
    }

    public async Task<FuelHistory?> GetByIdAsync(int id)
    {
        var fuelHistory = await dbContext.FuelHistories.FirstOrDefaultAsync(x => x.Id == id);
        return fuelHistory;
    }

    public async Task<int> CreateAsync(FuelHistory car)
    {
        dbContext.FuelHistories.Add(car);
        await dbContext.SaveChangesAsync();
        return car.Id;
    }
    
    public async Task UpdateAsync(FuelHistory car)
    {
        dbContext.FuelHistories.Update(car);
        await dbContext.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(FuelHistory car)
    {
        dbContext.FuelHistories.Remove(car);
        await dbContext.SaveChangesAsync();
    }
}