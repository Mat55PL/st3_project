using CarManageSystem.Domain.Entities;

namespace CarManageSystem.Domain.Repositories;

public interface ICarsRepository
{
    Task<IEnumerable<Car>> GetAllAsync();
    Task<Car?> GetByIdAsync(int id);
    Task<int> CreateAsync(Car car);
    Task DeleteAsync(int id);
    Task UpdateAsync(Car car);
}