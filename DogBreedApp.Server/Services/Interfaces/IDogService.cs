using DogBreedApp.Shared.DTO;

namespace DogBreedApp.Server.Services.Interfaces
{
    public interface IDogService
    {
        Task<List<DogDto>> GetDogsAsync();
        Task AddDogAsync(DogDto dogDto);
        Task<List<DogDto>> GetDogsByBreedId(int breedId);
    }
}
