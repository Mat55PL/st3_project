using CarManageSystem.Application.CarsFuelHistory.Dtos;
using CarManageSystem.Domain.Entities;
using CarManageSystem.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CarManageSystem.Application.CarsFuelHistory;

public class CarsFuelHistoryService(IFuelHistoryRepository fuelHistoryRepository, ILogger<CarsFuelHistoryService> logger) : ICarsFuelHistoryService
{
    public async Task<IEnumerable<FuelHistory>> GetAllFuelHistoryAsync()
    {
        logger.LogInformation("Getting all fuel history");
        var fuelHistory = await fuelHistoryRepository.GetAllAsync();
        return fuelHistory;
    }

    public async Task<FuelHistory?> GetFuelHistoryByIdAsync(int id)
    {
        logger.LogInformation("Getting fuel history by id {Id}", id);
        var fuelHistory = await fuelHistoryRepository.GetByIdAsync(id);
        return fuelHistory;
    }

    public async Task<IEnumerable<FuelHistory>> GetFuelHistoryByCarIdAsync(int carId)
    {
        logger.LogInformation("Getting fuel history by car id {CarId}", carId);
        var fuelHistory = await fuelHistoryRepository.GetByCarIdAsync(carId);
        return fuelHistory;
    }

    public async Task<FuelHistory> AddFuelHistoryAsync(CreateFuelHistoryDto createFuelHistoryDto)
    {
        logger.LogInformation("Adding fuel history for car id {CarId}", createFuelHistoryDto.CarId);
        var fuelHistory = new FuelHistory
        {
            CarId = createFuelHistoryDto.CarId,
            FuelAmount = createFuelHistoryDto.FuelAmount,
            FuelType =  createFuelHistoryDto.FuelType,
            Odometer = createFuelHistoryDto.Odometer,
            Cost = createFuelHistoryDto.Cost,
            Location = createFuelHistoryDto.Location,
            Note = createFuelHistoryDto.Note,
            Date = createFuelHistoryDto.Date
        };
        await fuelHistoryRepository.CreateAsync(fuelHistory);
        return fuelHistory;
    }

    public async Task UpdateFuelHistoryAsync(int id, FuelHistoryDto fuelHistoryDto)
    {
        logger.LogInformation("Updating fuel history for id {Id}", fuelHistoryDto.Id);
        var existingFuelHistory = await fuelHistoryRepository.GetByIdAsync(fuelHistoryDto.Id);
        if (existingFuelHistory == null)
        {
            throw new KeyNotFoundException($"Fuel history with id {fuelHistoryDto.Id} not found.");
        }

        existingFuelHistory.CarId = fuelHistoryDto.CarId;
        existingFuelHistory.FuelAmount = fuelHistoryDto.FuelAmount;
        existingFuelHistory.FuelType = fuelHistoryDto.FuelType;
        existingFuelHistory.Odometer = fuelHistoryDto.Odometer;
        existingFuelHistory.Cost = fuelHistoryDto.Cost;
        existingFuelHistory.Location = fuelHistoryDto.Location;
        existingFuelHistory.Note = fuelHistoryDto.Note;
        existingFuelHistory.Date = fuelHistoryDto.Date;

        await fuelHistoryRepository.UpdateAsync(existingFuelHistory);
    }

    public async Task DeleteFuelHistoryAsync(int id)
    {
        logger.LogInformation("Deleting fuel history for id {Id}", id);
        var existingFuelHistory = await fuelHistoryRepository.GetByIdAsync(id);
        if (existingFuelHistory == null)
        {
            throw new KeyNotFoundException($"Fuel history with id {id} not found.");
        }

        await fuelHistoryRepository.DeleteAsync(existingFuelHistory);
    }
}