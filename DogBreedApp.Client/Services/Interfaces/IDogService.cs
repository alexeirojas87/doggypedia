using DogBreedApp.Shared.DTO;

namespace DogBreedApp.Client.Services.Interfaces
{
    public interface IDogService
    {
        Task<List<DogDto>> GetDogsAsync();
        Task AddDogAsync(DogDto dog);
        Task<List<DogDto>> GetDogsByBreedAsync(int breedId);
    }
}
