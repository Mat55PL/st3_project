using CarDocuments.Domain.Entities;
using CarDocuments.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace CarDocuments.Application.Documents;

internal class DocumentsService(IDocumentsRepository documentsRepository, ILogger<DocumentsService> logger) : IDocumentsService
{
    public async Task<IEnumerable<Document>> GetAllDocuments()
    {
        logger.LogInformation("Getting all documents");
        var documents = await documentsRepository.GetAllAsync();
        return documents;
    }

    public async Task<Document?> GetById(int id)
    {
        logger.LogInformation("Getting document by id: {id}", id);
        var document = await documentsRepository.GetByIdAsync(id);
        return document;
    }

    public async Task<IEnumerable<Document>> GetByCarId(int carId)
    {
        logger.LogInformation("Getting documents by car id: {carId}", carId);
        var documents = await documentsRepository.GetByCarIdAsync(carId);
        return documents;
    }
}