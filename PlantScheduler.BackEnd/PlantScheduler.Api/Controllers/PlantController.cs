using Microsoft.AspNetCore.Mvc;
using PlantScheduler.Api.Models;
using PlantScheduler.Api.Repositories;

namespace PlantScheduler.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantController : ControllerBase
    {
        PlantRepository _plantRepository;
        public PlantController(PlantRepository plantRepository)
        {
            _plantRepository = plantRepository;
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<PlantDto>> GetPlants()
        {
            var plants = _plantRepository.GetPlants();
            return Ok(plants);
        }

        [HttpPost("create")]
        public ActionResult AddPlant([FromBody] PlantDto plant)
        {
            var isSuccess = _plantRepository.AddPlant(plant);
            
            if (!isSuccess)
                return StatusCode(500, "An error occurred while adding the plant.");

            return Ok();
        }
    }
}