using CarDocuments.Domain.Entities;
using CarDocuments.Domain.Repositories;
using CarDocuments.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarDocuments.Infrastructure.Repositories;

internal class DocumentsRepository(DocumentDbContext dbContext) : IDocumentsRepository
{
    public async Task<IEnumerable<Document>> GetAllAsync()
    {
        var documents = await dbContext.Documents.ToListAsync();
        return documents;
    }

    public async Task<Document?> GetByIdAsync(int id)
    {
        var document = await dbContext.Documents.FirstOrDefaultAsync(x => x.Id == id);
        return document;
    }

    public async Task<IEnumerable<Document>> GetByCarIdAsync(int carId)
    {
        var documents = await dbContext.Documents.Where(x => x.CarId == carId).ToListAsync();
        return documents;
    }
}