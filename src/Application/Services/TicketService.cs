//using ApiIntegrationExample.Application.Interfaces;
//using System.Collections.Concurrent;

//public class TicketService
//{
//	// This will store the dynamically registered Refit API clients for each airline.
//	private readonly ConcurrentDictionary<string, IAirlineApi> _airlineApiClients;

//	// The constructor takes the ConcurrentDictionary containing all Refit clients.
//	public TicketService(ConcurrentDictionary<string, IAirlineApi> airlineApiClients)
//	{
//		_airlineApiClients = airlineApiClients;
//	}

//	// Fetch ticket details dynamically from the corresponding airline API using its route
//	public async Task<TicketDetails> GetTicketDetailsAsync(string airlineName, string route)
//	{
//		// Look up the client for the specified airline
//		if (_airlineApiClients.TryGetValue(airlineName, out var airlineApi))
//		{
//			// Send a GET request to the airline's API to get ticket details
//			var response = await airlineApi.GetTicketDetailsAsync(route);

//			// If the response is successful, return the ticket details
//			if (response.IsSuccessStatusCode)
//			{
//				return response.Content;  // Return the ticket details content from the API response
//			}

//			// If not successful, throw an exception with the status code
//			throw new Exception($"Error fetching ticket details for {airlineName}: {response.StatusCode}");
//		}

//		// If the airline client was not found, throw an exception
//		throw new Exception($"Airline API client for {airlineName} not found.");
//	}

//	// Place a booking dynamically using the airline name and route
//	public async Task<BookingConfirmation> BookTicketAsync(string airlineName, string route, BookingRequest bookingRequest)
//	{
//		// Look up the client for the specified airline
//		if (_airlineApiClients.TryGetValue(airlineName, out var airlineApi))
//		{
//			// Send a POST request to the airline's API to book the ticket
//			var response = await airlineApi.BookTicketAsync(route, bookingRequest);

//			// If the response is successful, return the booking confirmation
//			if (response.IsSuccessStatusCode)
//			{
//				return response.Content;  // Return the booking confirmation from the API response
//			}

//			// If not successful, throw an exception with the status code
//			throw new Exception($"Error booking ticket for {airlineName}: {response.StatusCode}");
//		}

//		// If the airline client was not found, throw an exception
//		throw new Exception($"Airline API client for {airlineName} not found.");
//	}
//}
