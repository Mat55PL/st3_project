using CarManageSystem.Domain.Entities;
using CarManageSystem.Infrastructure.Persistence;

namespace CarManageSystem.Infrastructure.Seeders;

internal class CarSeeder(CarDbContext context) : ICarSeeder
{
    public async Task Seed()
    {
        if (await context.Database.CanConnectAsync())
        {
            if(!context.Cars.Any())
            {
                var cars = GetCars();
                context.Cars.AddRange(cars);
                await context.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Car> GetCars()
    {
        List<Car> cars = new()
        {
            new Car
            {
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2021,
                FuelType = CarFuelType.Gasoline,
                WheelType = TyreType.Summer,
                NumberPlate = "ABC123",
                Vin = "JTNK4RBE0K3040001"
            },
            new Car
            {
                Brand = "Ford",
                Model = "Focus",
                Year = 2020,
                FuelType = CarFuelType.Diesel,
                WheelType = TyreType.Winter,
                NumberPlate = "DEF456",
                Vin = "1FADP3K2XFL000000"
            },
            new Car
            {
                Brand = "Tesla",
                Model = "Model 3",
                Year = 2022,
                FuelType = CarFuelType.Electric,
                WheelType = TyreType.AllSeason,
                NumberPlate = "GHI789",
                Vin = "5YJ3E1EA7KF000000"
            }
        };
        
        return cars;
    }
}