using ApiIntegrationExample.Application.DTOs;
using ApiIntegrationExample.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiIntegrationExample.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AirlineController : ControllerBase
	{
		private readonly IAirlineService _airlineService;

		public AirlineController(IAirlineService airlineService)
		{
			_airlineService = airlineService;
		}

		[HttpGet("flights/{airlineName}")]
		public async Task<IActionResult> GetFlightDetailsAsync(string airlineName)
		{
			try
			{
				var flightDetails = await _airlineService.GetFlightDetailsAsync(airlineName);
				return Ok(flightDetails);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message); // Handle case when airline not found
			}
		}

		[HttpPost("book/{airlineName}")]
		public async Task<IActionResult> BookTicketAsync(string airlineName, [FromBody] TicketDto ticketDto)
		{
			try
			{
				var bookingResponse = await _airlineService.BookTicketAsync(airlineName, ticketDto);
				return Ok(bookingResponse);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message); // Handle case when airline not found
			}
		}
	}
}
