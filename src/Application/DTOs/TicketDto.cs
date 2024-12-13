using ApiIntegrationExample.Application.Dtos;

namespace ApiIntegrationExample.Application.DTOs
{
	public class TicketDto
	{
		// Initialize with default empty string to avoid null reference warnings
		public string TicketNumber { get; set; } = string.Empty;

		// Use null-forgiving operator to indicate that Flight will never be null
		public FlightDetailsDto Flight { get; set; } = null!;

		// Initialize with default empty string to avoid null reference warnings
		public string PassengerName { get; set; } = string.Empty;

		// Decimal is a non-nullable value type, so no change needed here
		public decimal Price { get; set; }
	}
}
