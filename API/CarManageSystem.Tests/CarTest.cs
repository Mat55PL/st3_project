using CarManageSystem.Domain.Entities;
using CarManageSystem.Application.Cars;
using CarManageSystem.Application.Cars.Dtos;
using CarManageSystem.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
namespace CarManageSystem.Tests;

public class CarTest
{
    private Mock<ICarsRepository> _carsRepositoryMock;
    private Mock<ILogger<CarsService>> _loggerMock;
    private CarsService _carsService;
    [SetUp]
    public void Setup()
    {
        _carsRepositoryMock = new Mock<ICarsRepository>();
        _loggerMock = new Mock<ILogger<CarsService>>();
        _carsService = new CarsService(_carsRepositoryMock.Object, _loggerMock.Object);
    }

    [Test]
    public async Task GetAllCars_ShouldReturnAllCars()
    {
        var cars = new List<Car>
        {
            new Car { Id = 1, Brand = "Toyota", Model = "Corolla", Vin = "12345678901234567", Year = 2020, FuelType = CarFuelType.Gasoline, WheelType = TyreType.Summer, NumberPlate = "ABC123" },
            new Car { Id = 2, Brand = "Ford", Model = "Focus", Vin = "23456789012345678", Year = 2019, FuelType = CarFuelType.Diesel, WheelType = TyreType.Winter, NumberPlate = "DEF456" }
        };
        _carsRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(cars);
        
        var result = await _carsService.GetAllCars();
        
        Assert.That(result, Is.EqualTo(cars));
        _loggerMock.Verify(log => log.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Getting all cars")),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()!), Times.Once);
    }
    
    [Test]
    public async Task Create_ShouldReturnNewCarId()
    {
        // Arrange
        var createCarDto = new CreateCarDto
        {
            Brand = "Toyota",
            Model = "Corolla",
            Vin = "12345678901234567",
            Year = 2020,
            FuelType = CarFuelType.Gasoline,
            WheelType = TyreType.Summer,
            NumberPlate = "ABC123"
        };
        _carsRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<Car>())).ReturnsAsync(1);

        // Act
        var result = await _carsService.Create(createCarDto);

        // Assert
        Assert.That(result, Is.EqualTo(1));
        _loggerMock.Verify(log => log.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Creating car")),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()!), Times.Once);
    }
    
    [Test]
    public async Task Update_ShouldCallUpdateOnRepository()
    {
        // Arrange
        var updateCarDto = new CarDto
        {
            Brand = "Toyota",
            Model = "Corolla",
            Vin = "12345678901234567",
            Year = 2020,
            FuelType = CarFuelType.Gasoline,
            WheelType = TyreType.Summer,
            NumberPlate = "ABC123"
        };

        // Act
        await _carsService.Update(1, updateCarDto);

        // Assert
        _carsRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Car>(c => c.Id == 1 && c.Brand == "Toyota" && c.Model == "Corolla")), Times.Once);
        _loggerMock.Verify(log => log.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Updating car by id")),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()!), Times.Once);
    }
}