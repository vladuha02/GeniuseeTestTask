using System.ComponentModel.DataAnnotations;
using GeniuseeTestTask.Abstractions;
using GeniuseeTestTask.Data;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GeniuseeTestTask.Controllers
{
    /// <summary>
    /// Operations relating to rainfall
    /// </summary>
    [ApiController]
    [Route("rainfall/id/{stationId}/readings")]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallServices _rainfallServices;
        private readonly IValidateInputDataServices _validateInputDataServices;

        public RainfallController(IRainfallServices rainfallServices, IValidateInputDataServices validateInputDataServices)
        {
            _rainfallServices = rainfallServices;
            _validateInputDataServices = validateInputDataServices;
        }

        /// <summary>
        /// Get rainfall readings by station Id
        /// </summary>
        /// <remarks>Retrieve the latest readings for the specified stationId</remarks>
        /// <param name="stationId">The id of the reading station</param>
        /// <param name="count">The number of readings to return</param>
        [HttpGet(Name = "get-rainfall")]
        [SwaggerResponse(200, "A list of rainfall readings successfully retrieved", typeof(RainfallReadingResponseModel), "application/json")]
        [SwaggerResponse(400, "Invalid request", typeof(RainfallReadingErrorResponseModel), "application/json")]
        [SwaggerResponse(404, "No requests found for the specified stationId", typeof(RainfallReadingErrorResponseModel), "application/json")]
        [SwaggerResponse(500, "Internal server error", typeof(RainfallReadingErrorResponseModel), "application/json")]
        public async Task<IActionResult> Get([FromRoute]string stationId, [FromQuery][Required][Range(1, 100)]int count = 10)
        {
            var validationResult = _validateInputDataServices.Validate(stationId);
            if (!validationResult)
            {
                return BadRequest(new RainfallReadingErrorResponseModel
                {
                    Message = "Invalid request",
                    Detail = new []
                    {
                        new RainfallReadingErrorDetailModel
                        {
                            Message = "Input data is invalid",
                            PropertyName = "stationId"
                        }
                    }
                });
            }

            try
            {
                var result = await _rainfallServices.GetReadingsByStationIdAsync(stationId, count);
                if (result.Readings.Length == 0)
                {
                    return NotFound(new RainfallReadingErrorResponseModel
                    {
                        Message = "No readings found for the specified stationId"
                    });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new RainfallReadingErrorResponseModel
                {
                    Message = ex.Message
                });
            }
        }
    }
}