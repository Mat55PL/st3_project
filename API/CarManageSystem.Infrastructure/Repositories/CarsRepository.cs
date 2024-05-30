using CarManageSystem.Domain.Entities;
using CarManageSystem.Domain.Repositories;
using CarManageSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarManageSystem.Infrastructure.Repositories;

internal class CarsRepository(CarDbContext dbContext) : ICarsRepository
{
    public async Task<IEnumerable<Car>> GetAllAsync()
    {
        var cars = await dbContext.Cars.ToListAsync();
        return cars;
    }

    public async Task<Car?> GetByIdAsync(int id)
    {
        var car = await dbContext.Cars.FirstOrDefaultAsync(x=> x.Id == id);
        return car;
    }

    public async Task<int> CreateAsync(Car car)
    {
        dbContext.Cars.Add(car);
        await dbContext.SaveChangesAsync();
        return car.Id;
    }

    public Task DeleteAsync(int id)
    {
        var car = new Car { Id = id };
        dbContext.Cars.Remove(car);
        return dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Car car)
    {
        dbContext.Cars.Update(car);
        await dbContext.SaveChangesAsync();
    }
}