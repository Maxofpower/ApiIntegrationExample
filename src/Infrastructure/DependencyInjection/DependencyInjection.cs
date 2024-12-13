using ApiIntegrationExample.Application.Interfaces;
using ApiIntegrationExample.Application.Services;
using ApiIntegrationExample.Infrastructure.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace ApiIntegrationExample.Infrastructure.DependencyInjection
{
	public static class ServiceRegistrationExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			// Register application services
			services.AddScoped<IAirlineService, AirlineService>();

			// Register the airline API client and other dependencies
			services.AddScoped<IAirlineApiClient, AirlineApiClient>();

			return services;
		}
	}
}
