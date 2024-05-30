using CarDocuments.Domain.Repositories;
using CarDocuments.Infrastructure.Persistence;
using CarDocuments.Infrastructure.Repositories;
using CarDocuments.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarDocuments.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DocumentsDbConnection");
        var serverVersion = ServerVersion.AutoDetect(connectionString);
        services.AddDbContext<DocumentDbContext>(options => options.UseMySql(connectionString, serverVersion));
        
        services.AddScoped<IDocumentsRepository, DocumentsRepository>();
        services.AddScoped<IDocumentSeeder, DocumentSeeder>();
    }
}