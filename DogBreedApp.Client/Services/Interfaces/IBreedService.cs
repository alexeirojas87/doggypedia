using DogBreedApp.Shared.DTO;

namespace DogBreedApp.Client.Services.Interfaces
{
    public interface IBreedService
    {
        Task<IEnumerable<BreedDto>> GetBreedsAsync();
        Task<BreedDto> AddBreedAsync(BreedDto breed);
    }
}
