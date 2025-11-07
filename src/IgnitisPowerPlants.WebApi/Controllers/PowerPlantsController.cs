using IgnitisPowerPlants.Application.Queries;
using IgnitisPowerPlants.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace IgnitisPowerPlants.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PowerPlantsController : Controller
    {
        private readonly GetPowerPlantsHandler _getPowerPlantsHandler;

        public PowerPlantsController(GetPowerPlantsHandler getPowerPlantsHandler)
        {
            _getPowerPlantsHandler = getPowerPlantsHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] int? pageNumber, int? pageSize)
        {
            var response = await _getPowerPlantsHandler.HandleAsync(new GetPowerPlantQuery(pageNumber, pageSize));
            return Ok(response);
        }
    }
}
