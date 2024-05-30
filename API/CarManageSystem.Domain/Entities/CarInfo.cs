namespace CarManageSystem.Domain.Entities;

public class CarInfo
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public DateOnly InspectionDate { get; set; }
    public DateOnly InsuranceDate { get; set; }
    public DateOnly OilChangeDate { get; set; }
    public DateOnly TireChangeDate { get; set; }
}