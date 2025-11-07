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
        public async Task<IActionResult> GetAsync()
        {
            var response = await _getPowerPlantsHandler.HandleAsync();
            return Ok(response.PowerPlants);
        }
    }
}
