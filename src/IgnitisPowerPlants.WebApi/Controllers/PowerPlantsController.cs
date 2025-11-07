using IgnitisPowerPlants.Application.Commands;
using IgnitisPowerPlants.Application.Exceptions;
using IgnitisPowerPlants.Application.Queries;
using IgnitisPowerPlants.Application.UseCases;
using IgnitisPowerPlants.WebApi.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace IgnitisPowerPlants.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PowerPlantsController : Controller
    {
        private readonly GetPowerPlantsHandler _getPowerPlantsHandler;
        private readonly CreatePowerPlantHandler _createPowerPlantHandler;

        public PowerPlantsController(GetPowerPlantsHandler getPowerPlantsHandler, CreatePowerPlantHandler createPowerPlantHandler)
        {
            _getPowerPlantsHandler = getPowerPlantsHandler;
            _createPowerPlantHandler = createPowerPlantHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] int? pageNumber, int? pageSize, string? owner)
        {
            var response = await _getPowerPlantsHandler.HandleAsync(new GetPowerPlantQuery(pageNumber, pageSize, owner));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePowerPlantRequest request)
        {
            var command = new CreatePowerPlantCommand(
                request.Owner,
                request.Power,
                request.ValidFrom,
                request.ValidTo
            );

            try
            {
                await _createPowerPlantHandler.HandleAsync(command);
                return Created();
            }
            catch (PowerPlantValidationException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "An unexpected error occurred." });
            }
        }
    }
}
