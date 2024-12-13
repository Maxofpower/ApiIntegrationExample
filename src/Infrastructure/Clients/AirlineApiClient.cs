using ApiIntegrationExample.Application.Dtos;
using ApiIntegrationExample.Application.DTOs;
using ApiIntegrationExample.Application.Interfaces;
using ApiIntegrationExample.Infrastructure.Configuraion;
using Microsoft.Extensions.Options;
using Refit;
using Polly;
using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiIntegrationExample.Infrastructure.Clients
{
	public class AirlineApiClient : IAirlineApiClient
	{
		private readonly IOptions<ApiConfig> _apiConfig;
		private readonly ConcurrentDictionary<string, IAirlineApi> _airlineApiClients;
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILogger<AirlineApiClient> _logger;

		public AirlineApiClient(IOptions<ApiConfig> apiConfig, IHttpClientFactory httpClientFactory, ILogger<AirlineApiClient> logger)
		{
			_apiConfig = apiConfig ?? throw new ArgumentNullException(nameof(apiConfig));
			_httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
			_airlineApiClients = new ConcurrentDictionary<string, IAirlineApi>();
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));

			// Validate API configuration
			var airlines = _apiConfig.Value?.Airlines ?? throw new ArgumentException("No airline configurations found.");

			if (!airlines.Any())
			{
				throw new ArgumentException("No airline configurations found.");
			}

			// Create Refit clients dynamically for each airline, with Polly policies applied
			foreach (var airline in airlines)
			{
				var client = _httpClientFactory.CreateClient("AirlineApiClient"); // Get the named HttpClient with Polly policies
				client.BaseAddress = new Uri(airline.Value.BaseUrl ?? throw new ArgumentNullException(nameof(airline.Value.BaseUrl))); // Set the base address for the airline API

				// Create the Refit client and add it to the dictionary
				_airlineApiClients[airline.Key] = RestService.For<IAirlineApi>(client);
			}
		}

		// Try to get the Refit client for a specific airline
		public bool TryGetApiClient(string airlineName, out IAirlineApi airlineApi)
		{
			if (string.IsNullOrWhiteSpace(airlineName))
			{
				throw new ArgumentException("Airline name cannot be null or whitespace.", nameof(airlineName));
			}

			return _airlineApiClients.TryGetValue(airlineName, out airlineApi!);
		}

		
	}
}
