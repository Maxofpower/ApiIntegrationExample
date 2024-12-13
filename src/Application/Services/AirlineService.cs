using ApiIntegrationExample.Application.Dtos;
using ApiIntegrationExample.Application.DTOs;
using ApiIntegrationExample.Application.Interfaces;
using ApiIntegrationExample.Infrastructure.Configuraion;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiIntegrationExample.Application.Services
{
	public class AirlineService : IAirlineService
	{
		private readonly IAirlineApiClient _airlineApiClient;
		private readonly IOptions<ApiConfig> _apiConfig;

		public AirlineService(IAirlineApiClient airlineApiClient, IOptions<ApiConfig> apiConfig)
		{
			_airlineApiClient = airlineApiClient;
			_apiConfig = apiConfig;
		}

		public async Task<List<FlightDetailsDto>> GetFlightDetailsAsync(string airlineName)
		{
			// Check if the airline API client exists in the dictionary
			var airlineApi = _airlineApiClient.TryGetApiClient(airlineName, out var api) ? api : throw new ArgumentException($"API client not found for airline '{airlineName}'.");

			var airlineConfig = _apiConfig?.Value?.Airlines?.GetValueOrDefault(airlineName) ?? throw new ArgumentException($"Airline configuration not found for airline '{airlineName}'.");

			var route = airlineConfig?.Routes?.GetValueOrDefault("GetTickets") ?? throw new ArgumentException($"Route 'GetTickets' not found for airline '{airlineName}'.");

			var flightDetails = await airlineApi.GetFlightDetailsAsync(route) ?? throw new InvalidOperationException("Failed to retrieve flight details.");

			return flightDetails.Select(f => new FlightDetailsDto
			{
				FlightNumber = f.FlightNumber,
				DepartureTime = f.DepartureTime,
				ArrivalTime = f.ArrivalTime,
				From = f.From,
				To = f.To
			}).ToList();


			throw new ArgumentException($"Airline {airlineName} not found in configuration.");
		}

		public async Task<TicketBookingResponse> BookTicketAsync(string airlineName, TicketDto ticketDto)
		{
			// Retrieve the airline API client or throw an exception if not found
			var airlineApi = _airlineApiClient.TryGetApiClient(airlineName, out var api) ? api : throw new ArgumentException($"API client not found for airline '{airlineName}'.");

			// Retrieve the airline configuration from the API config or throw an exception if not found
			var airlineConfig = _apiConfig?.Value?.Airlines?.GetValueOrDefault(airlineName) ?? throw new ArgumentException($"Airline configuration not found for airline '{airlineName}'.");

			// Retrieve the "BookTicket" route or throw an exception if not found
			var route = airlineConfig?.Routes?.GetValueOrDefault("BookTicket") ?? throw new ArgumentException($"Route 'BookTicket' not found for airline '{airlineName}'.");

			// Book a ticket through the API using the route
			var bookingResponse = await airlineApi.BookTicketAsync(route, ticketDto);

			return bookingResponse ?? throw new InvalidOperationException("Failed to book ticket.");
		}

	}
}
