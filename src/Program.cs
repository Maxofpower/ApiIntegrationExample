using ApiIntegrationExample.Infrastructure.Clients;
using ApiIntegrationExample.Application.Interfaces;
using ApiIntegrationExample.Infrastructure.Configuraion;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;
using Microsoft.Extensions.Logging;
using ApiIntegrationExample.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


// Configure Polly policies
var retryPolicy = HttpPolicyExtensions
	.HandleTransientHttpError()
	.Or<TimeoutRejectedException>()
	.WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

var circuitBreakerPolicy = HttpPolicyExtensions
	.HandleTransientHttpError()
	.CircuitBreakerAsync(2, TimeSpan.FromMinutes(1));

// Register policies for HttpClient
builder.Services.AddHttpClient("AirlineApiClient")
	.AddPolicyHandler(retryPolicy)
	.AddPolicyHandler(circuitBreakerPolicy);

// Register your application services (use your own method or add here directly)
builder.Services.AddApplicationServices();

// Configure other services (e.g., controllers, routing)
builder.Services.AddControllers();

// Set up configuration for ApiConfig from appsettings.json
builder.Services.Configure<ApiConfig>(builder.Configuration.GetSection("ApiConfig"));

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Build the application
var app = builder.Build();

// Use your middleware and routing
app.MapControllers();

// Run the app
app.Run();
