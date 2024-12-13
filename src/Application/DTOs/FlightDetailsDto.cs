namespace ApiIntegrationExample.Application.Dtos
{
	public class FlightDetailsDto
	{
		// Initialize with default empty string to avoid null reference warnings
		public string FlightNumber { get; set; } = string.Empty;

		// DateTime is a non-nullable value type, so no change needed here
		public DateTime DepartureTime { get; set; }
		public DateTime ArrivalTime { get; set; }

		// Initialize with default empty string to avoid null reference warnings
		public string From { get; set; } = string.Empty;
		public string To { get; set; } = string.Empty;
	}
}
