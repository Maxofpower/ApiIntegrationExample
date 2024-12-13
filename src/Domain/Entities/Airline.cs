namespace ApiIntegrationExample.Domain.Entities
{
	public class Airline
	{
		// Mark properties as nullable if they can be null
		public string Name { get; set; } = string.Empty; // Default to empty string to avoid null
		public string BaseUrl { get; set; } = string.Empty; // Default to empty string to avoid null
		public Dictionary<string, string> Routes { get; set; } = new Dictionary<string, string>(); // Initialize with an empty dictionary to avoid null
	}
}
