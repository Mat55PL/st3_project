using CarManageSystem.Domain.Entities;

namespace CarManageSystem.Domain.Repositories;

public interface IFuelHistoryRepository
{
    Task<IEnumerable<FuelHistory>> GetAllAsync();
    Task<IEnumerable<FuelHistory>> GetByCarIdAsync(int carId);
    Task<FuelHistory?> GetByIdAsync(int id);
    Task<int> CreateAsync(FuelHistory car);
    Task UpdateAsync(FuelHistory car);
    Task DeleteAsync(FuelHistory car);
}