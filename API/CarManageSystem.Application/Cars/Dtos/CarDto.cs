using CarManageSystem.Domain.Entities;

namespace CarManageSystem.Application.Cars.Dtos;

public class CarDto
{
    public int Id { get; set; }
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public int Year { get; set; }
    public string Vin { get; set; } = default!;
    public CarFuelType FuelType { get; set; }
    public TyreType WheelType { get; set; }
    public string NumberPlate { get; set; } = default!;
}