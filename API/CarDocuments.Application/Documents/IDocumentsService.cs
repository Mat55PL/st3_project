using CarDocuments.Domain.Entities;

namespace CarDocuments.Application.Documents;

public interface IDocumentsService
{
    Task<IEnumerable<Document>> GetAllDocuments();
    Task<Document?> GetById(int id);
    Task<IEnumerable<Document>> GetByCarId(int carId);
}