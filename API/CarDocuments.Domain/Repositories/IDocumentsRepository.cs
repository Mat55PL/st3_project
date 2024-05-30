using CarDocuments.Domain.Entities;

namespace CarDocuments.Domain.Repositories;

public interface IDocumentsRepository
{
    Task<IEnumerable<Document>> GetAllAsync();
    Task<Document?> GetByIdAsync(int id);
    Task<IEnumerable<Document>> GetByCarIdAsync(int carId);
}