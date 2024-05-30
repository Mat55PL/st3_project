namespace CarDocuments.Domain.Entities;

public class Document
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int CarId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}