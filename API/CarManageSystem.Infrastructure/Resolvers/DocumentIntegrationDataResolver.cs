using System.Net.Http.Json;
using CarDocuments.Application.Documents.Dtos;
using Microsoft.Extensions.Caching.Memory;

namespace CarManageSystem.Infrastructure.Resolvers;

public class DocumentIntegrationDataResolver
{
    private readonly HttpClient _httpClient;
    private readonly IMemoryCache _cache;
    private readonly string _documentApiUrl = "https://localhost:44346/api/Document";
    
    public DocumentIntegrationDataResolver(HttpClient httpClient, IMemoryCache cache)
    {
        _httpClient = httpClient;
        _cache = cache;
    }
    
    public async Task<DocumentDto> GetDocumentById(Guid id)
    {
        if (_cache.TryGetValue(id, out DocumentDto document))
        {
            return document;
        }
        
        var response = await _httpClient.GetAsync($"{_documentApiUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            document = await response.Content.ReadFromJsonAsync<DocumentDto>();
            _cache.Set(id, document, TimeSpan.FromMinutes(10));
            return document;
        }
        
        return null;
    }
}