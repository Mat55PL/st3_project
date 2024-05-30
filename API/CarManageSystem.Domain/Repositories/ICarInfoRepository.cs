using CarManageSystem.Domain.Entities;

namespace CarManageSystem.Domain.Repositories;

public interface ICarInfoRepository
{
    Task<IEnumerable<CarInfo>> GetAllAsync();
    Task<IEnumerable<CarInfo>> GetByCarIdAsync(int carId);
    Task<CarInfo?> GetByIdAsync(int id);
    Task<int> CreateAsync(CarInfo car);
    Task DeleteAsync(int id);
    Task UpdateAsync(int id, CarInfo car);
}