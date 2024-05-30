namespace CarManageSystem.Domain.Entities;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; } = default!;
    public string Model { get; set; } = default!;
    public string Vin { get; set; } = default!;
    public int Year { get; set; }
    public CarFuelType FuelType { get; set; }
    public TyreType WheelType { get; set; }
    public string NumberPlate { get; set; } = default!;
    
}

public enum CarFuelType
{
    Gasoline,
    Diesel,
    Electric,
    Hybrid
}

public enum TyreType
{
    Summer,
    Winter,
    AllSeason
}