using DogBreedApp.Server.Data;
using DogBreedApp.Server.Data.Models;
using DogBreedApp.Server.Services.Interfaces;
using DogBreedApp.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace DogBreedApp.Server.Services
{
    public class DogService : IDogService
    {
        private readonly AppDbContext _dbContext;

        public DogService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DogDto>> GetDogsAsync()
        {
            return await _dbContext.Dogs
                .Include(d => d.Breed)
                .Select(d => new DogDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    BreedId = d.BreedId,
                    BreedName = d.Breed.Name,
                    Sex = d.Sex,
                    BirthDate = d.BirthDate
                })
                .ToListAsync();
        }

        public async Task AddDogAsync(DogDto dogDto)
        {
            var dog = new Dog
            {
                Name = dogDto.Name,
                BreedId = dogDto.BreedId,
                Sex = dogDto.Sex,
                BirthDate = dogDto.BirthDate,
                FatherId = null, // No es necesario, ya que el valor predeterminado es null
                MotherId = null
            };

            _dbContext.Dogs.Add(dog);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<DogDto>> GetDogsByBreedId(int breedId)
        {
            return await _dbContext.Dogs
                .Where(d => d.BreedId == breedId)
                .Include(d => d.Breed)
                .Select(d => new DogDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    BreedId = d.BreedId,
                    BreedName = d.Breed.Name,
                    Sex = d.Sex,
                    BirthDate = d.BirthDate
                })
                .ToListAsync();
        }
    }
}
