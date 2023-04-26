using DogBreedApp.Server.Data.Models;

namespace DogBreedApp.Server.Services.Interfaces
{
    public interface IBreedService
    {
        Task<IEnumerable<Breed>> GetBreedsAsync();
        Task<Breed> AddBreedAsync(Breed breed);
    }
}
