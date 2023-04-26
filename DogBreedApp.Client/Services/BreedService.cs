using DogBreedApp.Client.Services.Interfaces;
using DogBreedApp.Shared.DTO;
using System.Net.Http.Json;
namespace DogBreedApp.Client.Services;
public class BreedService : IBreedService
{
    private readonly HttpClient _httpClient;

    public BreedService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<BreedDto>> GetBreedsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<BreedDto>>("api/Breeds");
    }

    public async Task<BreedDto> AddBreedAsync(BreedDto breed)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Breeds", breed);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<BreedDto>();
    }
}
