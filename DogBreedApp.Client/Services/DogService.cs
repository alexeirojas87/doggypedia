using DogBreedApp.Client.Services.Interfaces;
using DogBreedApp.Shared.DTO;
using System.Net.Http.Json;

namespace DogBreedApp.Client.Services
{
    public class DogService : IDogService
    {
        private readonly HttpClient _httpClient;

        public DogService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DogDto>> GetDogsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<DogDto>>("api/Dogs");
        }

        public async Task AddDogAsync(DogDto dog)
        {
            await _httpClient.PostAsJsonAsync("api/Dogs", dog);
        }

        public async Task<List<DogDto>> GetDogsByBreedAsync(int breedId)
        {
            return await _httpClient.GetFromJsonAsync<List<DogDto>>($"api/Dogs/{breedId}");
        }
    }
}
