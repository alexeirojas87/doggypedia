using DogBreedApp.Server.Data;
using DogBreedApp.Server.Data.Models;
using DogBreedApp.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DogBreedApp.Server.Services
{
    public class BreedService : IBreedService
    {
        private readonly AppDbContext _dbContext;

        public BreedService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Breed>> GetBreedsAsync()
        {
            return await _dbContext.Breeds.Include(d => d.Dogs).ToListAsync();
        }

        public async Task<Breed> AddBreedAsync(Breed breed)
        {
            try
            {
                _dbContext.Breeds.Add(breed);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return breed;
        }
    }
}
