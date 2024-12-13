using ApiIntegrationExample.Application.Dtos;
using ApiIntegrationExample.Application.DTOs;
using Refit;
using System.Threading.Tasks;

namespace ApiIntegrationExample.Application.Interfaces
{
	public interface IAirlineApi
	{
		[Get("/{route}")]
		Task<List<FlightDetailsDto>> GetFlightDetailsAsync(string route);

		[Post("/{route}")]
		Task<TicketBookingResponse> BookTicketAsync(string route, [Body] TicketDto ticketDto);
	}
}
