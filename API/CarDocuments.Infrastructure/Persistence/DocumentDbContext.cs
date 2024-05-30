using CarDocuments.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarDocuments.Infrastructure.Persistence;

internal class DocumentDbContext(DbContextOptions<DocumentDbContext> options) : DbContext(options)
{
    internal DbSet<Document> Documents { get; set; }
}