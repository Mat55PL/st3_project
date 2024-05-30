using CarDocuments.Application.Documents;
using Microsoft.Extensions.DependencyInjection;

namespace CarDocuments.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDocumentsService, DocumentsService>();
    }
}