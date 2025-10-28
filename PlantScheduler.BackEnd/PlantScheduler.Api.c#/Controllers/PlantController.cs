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
        ILogger<PlantController> _logger;
        public PlantController(ILogger<PlantController> logger, PlantRepository plantRepository)
        {
            _logger = logger;
            _plantRepository = plantRepository;
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<PlantDto>> GetPlants()
        {
            _logger.LogCritical("Fetching all plants");
            var plants = _plantRepository.GetPlants();
            return Ok(plants);
        }

        [HttpPost("create")]
        public ActionResult AddPlant([FromBody] PlantDto plant)
        {
            _logger.LogCritical("Adding a new plant: {@Plant}", plant);
            var isSuccess = _plantRepository.AddPlant(plant);
            
            _logger.LogCritical("Added plant success status: {IsSuccess}", isSuccess);
            if (!isSuccess)
                return StatusCode(500, "An error occurred while adding the plant.");

            return Ok();
        }
    }
}