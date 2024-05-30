using CarManageSystem.Application.CarsFuelHistory.Dtos;
using CarManageSystem.Domain.Entities;

namespace CarManageSystem.Application.CarsFuelHistory;

public interface ICarsFuelHistoryService
{
    Task<IEnumerable<FuelHistory>> GetAllFuelHistoryAsync();
    Task<FuelHistory?> GetFuelHistoryByIdAsync(int id);
    Task<IEnumerable<FuelHistory>> GetFuelHistoryByCarIdAsync(int carId);
    Task<FuelHistory> AddFuelHistoryAsync(CreateFuelHistoryDto createFuelHistoryDto);
    Task UpdateFuelHistoryAsync(int id, FuelHistoryDto fuelHistoryDto);
    Task DeleteFuelHistoryAsync(int id);
}