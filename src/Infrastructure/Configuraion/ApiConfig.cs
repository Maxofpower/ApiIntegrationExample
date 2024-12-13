using System.Collections.Concurrent;

namespace ApiIntegrationExample.Infrastructure.Configuraion
{
	public class ApiConfig
	{
		// Airlines can be null, and you can initialize it inline
		public ConcurrentDictionary<string, AirlineConfig>? Airlines { get; set; } = null;
	}

	public class AirlineConfig
	{
		public string? BaseUrl { get; set; } = null;
		public ConcurrentDictionary<string, string>? Routes { get; set; } = null;
	}
}
