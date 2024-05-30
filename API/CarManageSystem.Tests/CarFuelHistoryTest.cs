using CarManageSystem.Application.CarsFuelHistory;
using CarManageSystem.Domain.Entities;
using CarManageSystem.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace CarManageSystem.Tests;

public class CarFuelHistoryTest
{
    private Mock<IFuelHistoryRepository> _fuelHistoryRepositoryMock;
    private Mock<ILogger<CarsFuelHistoryService>> _loggerMock;
    private CarsFuelHistoryService _carsFuelHistoryService;
    
    [SetUp]
    public void Setup()
    {
        _fuelHistoryRepositoryMock = new Mock<IFuelHistoryRepository>();
        _loggerMock = new Mock<ILogger<CarsFuelHistoryService>>();
        _carsFuelHistoryService = new CarsFuelHistoryService(_fuelHistoryRepositoryMock.Object, _loggerMock.Object);
    }
    
    [Test]
    public async Task GetAllFuelHistoryAsync_ShouldReturnAllFuelHistory()
    {
        var fuelHistory = new List<FuelHistory>
        {
            new FuelHistory { Id = 1, CarId = 1, FuelAmount = 50, Cost = 100, Odometer = 10000, FuelType = CarFuelType.Gasoline, Location = "Station A", Note = "First fill", Date = DateTime.Now },
            new FuelHistory { Id = 2, CarId = 2, FuelAmount = 60, Cost = 120, Odometer = 20000, FuelType = CarFuelType.Diesel, Location = "Station B", Note = "Second fill", Date = DateTime.Now }
        };
        _fuelHistoryRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(fuelHistory);
        
        var result = await _carsFuelHistoryService.GetAllFuelHistoryAsync();
        
        Assert.That(result, Is.EqualTo(fuelHistory));
        _loggerMock.Verify(log => log.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Getting all fuel history")),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
    }
    
    [Test]
    public async Task GetFuelHistoryByIdAsync_ShouldReturnFuelHistory_WhenFuelHistoryExists()
    {
        var fuelHistory = new FuelHistory { Id = 1, CarId = 1, FuelAmount = 50, Cost = 100, Odometer = 10000, FuelType = CarFuelType.Gasoline, Location = "MOYATWOYA", Note = "First fill", Date = DateTime.Now };
        _fuelHistoryRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(fuelHistory);
        
        var result = await _carsFuelHistoryService.GetFuelHistoryByIdAsync(1);
        
        Assert.That(result, Is.EqualTo(fuelHistory));
        _loggerMock.Verify(log => log.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Getting fuel history by id")),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
    }

    [Test]
    public async Task DeleteFuelHistoryAsync_ShouldCallDeleteOnRepository()
    {
        var existingFuelHistory = new FuelHistory { Id = 1, CarId = 1, FuelAmount = 50, Cost = 100, Odometer = 10000, FuelType = CarFuelType.Gasoline, Location = "Rzeszów ORŁEN", Note = "First fill", Date = DateTime.Now };
        _fuelHistoryRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingFuelHistory);
        _fuelHistoryRepositoryMock.Setup(repo => repo.DeleteAsync(It.IsAny<FuelHistory>())).Returns(Task.CompletedTask);
        
        await _carsFuelHistoryService.DeleteFuelHistoryAsync(1);
        
        _fuelHistoryRepositoryMock.Verify(repo => repo.GetByIdAsync(1), Times.Once);
        _fuelHistoryRepositoryMock.Verify(repo => repo.DeleteAsync(It.Is<FuelHistory>(f => f.Id == 1)), Times.Once);
        _loggerMock.Verify(log => log.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Deleting fuel history for id")),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
    }

}