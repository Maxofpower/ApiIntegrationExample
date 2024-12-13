namespace ApiIntegrationExample.Application.Interfaces
{
	public interface IAirlineApiClient
	{
		bool TryGetApiClient(string airlineName, out IAirlineApi airlineApi);
	}
}
