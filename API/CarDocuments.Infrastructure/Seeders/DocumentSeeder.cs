using CarDocuments.Domain.Entities;
using CarDocuments.Infrastructure.Persistence;

namespace CarDocuments.Infrastructure.Seeders;

internal class DocumentSeeder(DocumentDbContext dbContext) : IDocumentSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if(!dbContext.Documents.Any())
            {
                var documents = GetDocuments();
                dbContext.Documents.AddRange(documents);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Document> GetDocuments()
    {
        List<Document> documents = new()
        {
            new Document()
            {
                Name = "Dowód rejestracyjny",
                CarId = 1,
                StartDate = new DateOnly(2021, 1, 1),
                EndDate = new DateOnly(2031, 1, 1)
            },
            new Document()
            {
                Name = "Ubezpieczenie OC",
                CarId = 1,
                StartDate = new DateOnly(2021, 1, 1),
                EndDate = new DateOnly(2022, 1, 1)
            },
            new Document()
            {
                Name = "Ubezpieczenie AC",
                CarId = 1,
                StartDate = new DateOnly(2021, 1, 1),
                EndDate = new DateOnly(2022, 1, 1)
            },
            new Document()
            {
                Name = "Dowód rejestracyjny",
                CarId = 2,
                StartDate = new DateOnly(2023, 1, 1),
                EndDate = new DateOnly(2033, 1, 1)
            }
        };
        
        return documents;
    }
}