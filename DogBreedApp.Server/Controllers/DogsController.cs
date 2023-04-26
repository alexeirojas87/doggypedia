using DogBreedApp.Server.Services.Interfaces;
using DogBreedApp.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DogBreedApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly IDogService _dogService;

        public DogsController(IDogService dogService)
        {
            _dogService = dogService;
        }

        // GET: api/Dogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DogDto>>> GetDogs()
        {
            return Ok(await _dogService.GetDogsAsync());
        }

        // POST: api/Dogs
        [HttpPost]
        public async Task<ActionResult<DogDto>> AddDog(DogDto dogDto)
        {
            await _dogService.AddDogAsync(dogDto);
            return CreatedAtAction(nameof(GetDogs), new { id = dogDto.Id }, dogDto);
        }
        [HttpGet]
        [Route("{breedId}")]
        public async Task<ActionResult<IEnumerable<DogDto>>> GetDogsByBreed(int breedId)
        {
            return Ok(await _dogService.GetDogsByBreedId(breedId));
        }
    }
}
