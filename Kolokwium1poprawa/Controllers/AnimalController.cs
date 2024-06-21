using Microsoft.AspNetCore.Mvc;
using Kolokwium1poprawa.Repositories;
using Kolokwium1poprawa.Models;
namespace Kolokwium1poprawa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        public class AnimalsController : ControllerBase
        {
            private readonly IAnimalRepository _animalRepository;
            public AnimalsController(IAnimalRepository animalsRepository)
            {
                _animalRepository = animalRepository;
            }
        
            [HttpGet("{id}")]
            public async Task<IActionResult> GetAnimal(int id)
            {
                if (!await _animalRepository.DoesAnimalExist(id))
                    return NotFound($"Animal with given ID - {id} doesn't exist");

                var animal = await _animalRepository.GetAnimal(id);
            
                return Ok(animal);

    }
}


