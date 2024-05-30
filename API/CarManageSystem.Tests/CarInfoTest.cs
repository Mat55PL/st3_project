using CarManageSystem.Domain.Entities;
using CarManageSystem.Application.CarsInfo;
using CarManageSystem.Application.CarsInfo.Dtos;
using CarManageSystem.Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;

namespace CarManageSystem.Tests;

public class CarInfoTest
{
    private Mock<ICarInfoRepository> _carInfoRepositoryMock;
    private Mock<ILogger<CarsInfoService>> _loggerMock;
    private CarsInfoService _carsInfoService;
    
    [SetUp]
    public void Setup()
    {
        _carInfoRepositoryMock = new Mock<ICarInfoRepository>();
        _loggerMock = new Mock<ILogger<CarsInfoService>>();
        _carsInfoService = new CarsInfoService(_carInfoRepositoryMock.Object, _loggerMock.Object);
    }
    
    [Test]
    public async Task GetCarInfoByIdAsync_ShouldReturnCarInfo_WhenCarInfoExists()
    {
        var carInfo = new CarInfo { Id = 1, CarId = 1, InspectionDate = new DateOnly(2022, 5, 1), InsuranceDate = new DateOnly(2022, 6, 1), OilChangeDate = new DateOnly(2022, 7, 1), TireChangeDate = new DateOnly(2022, 8, 1) };
        _carInfoRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(carInfo);
        
        var result = await _carsInfoService.GetCarInfoByIdAsync(1);

        Assert.That(result, Is.EqualTo(carInfo));
        _loggerMock.Verify(log => log.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Getting car info by id")),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
    }
    
    [Test]
    public async Task GetCarInfoByIdAsync_ShouldReturnNull_WhenCarInfoDoesNotExist()
    {
        _carInfoRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((CarInfo)null);
        
        var result = await _carsInfoService.GetCarInfoByIdAsync(1);
        
        Assert.That(result, Is.Null);
        _loggerMock.Verify(log => log.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Getting car info by id")),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
    }
    
    [Test]
    public async Task CreateCarInfoAsync_ShouldReturnNewCarInfoId()
    {
        // Arrange
        var createCarInfoDto = new CreateCarInfoDto
        {
            CarId = 1,
            InspectionDate = new DateOnly(2022, 5, 1),
            InsuranceDate = new DateOnly(2022, 6, 1),
            OilChangeDate = new DateOnly(2022, 7, 1),
            TireChangeDate = new DateOnly(2022, 8, 1)
        };
        _carInfoRepositoryMock.Setup(repo => repo.CreateAsync(It.IsAny<CarInfo>())).ReturnsAsync(1);

        // Act
        var result = await _carsInfoService.CreateCarInfoAsync(createCarInfoDto);

        // Assert
        Assert.That(result, Is.EqualTo(1));
        _loggerMock.Verify(log => log.Log(
            LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Creating car info")),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
    }
}