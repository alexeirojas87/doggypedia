using DogBreedApp.Server.Data.Models;
using DogBreedApp.Server.Services.Interfaces;
using DogBreedApp.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DogBreedApp.Server.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BreedsController : ControllerBase
{
    private readonly IBreedService _breedService;

    public BreedsController(IBreedService breedService)
    {
        _breedService = breedService;
    }
    [HttpGet]
    public async Task<IEnumerable<BreedDto>> GetBreeds()
    {
        var breeds = await _breedService.GetBreedsAsync();
        return breeds.Select(b => new BreedDto { Id = b.Id, Name = b.Name, DogCount = b.Dogs.Count });
    }

    [HttpPost]
    public async Task<ActionResult<BreedDto>> AddBreed(BreedDto breedDto)
    {
        var breed = new Breed { Name = breedDto.Name };
        breed = await _breedService.AddBreedAsync(breed);

        return CreatedAtAction(nameof(GetBreeds), new { id = breed.Id }, new BreedDto { Id = breed.Id, Name = breed.Name });
    }
}
