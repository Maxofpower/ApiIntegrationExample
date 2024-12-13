using ApiIntegrationExample.Application.Dtos;
using ApiIntegrationExample.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiIntegrationExample.Application.Interfaces
{
	public interface IAirlineService
	{
		Task<List<FlightDetailsDto>> GetFlightDetailsAsync(string airlineName);
		Task<TicketBookingResponse> BookTicketAsync(string airlineName, TicketDto ticketDto);
	}
}
