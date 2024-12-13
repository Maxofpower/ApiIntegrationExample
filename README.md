# 🔥 Refit and Polly for a High-Volume E-Commerce System (sample: Airline Ticket Sales)

This project demonstrates how to effectively use Refit and Polly to scale API integrations in a high-volume e-commerce system, specifically for integrating with over 100 different airline APIs to sell airplane tickets.

## Key Features

- **Single Interface for All APIs:** Uses a single Refit interface for dynamic route and configuration loading.
- **Dynamic API Client Registration:** Configures and registers Refit clients dynamically from configuration files.
- **Polly for Resilience:** Implements Polly for retries, circuit breakers, and resilience to handle transient failures and slow responses.
- **SOLID Design Principles:** Adheres to SOLID principles to maintain clean, maintainable, and scalable code.

## Benefits

- **Scalability:** As the number of APIs grows, managing separate interfaces and registrations for each becomes unwieldy. Dynamic registration simplifies this, making the system scalable.
- **Maintainability:** Centralizing the configuration allows for easy updates and reduces the risk of errors. If an API changes, you update the configuration, not the code.
- **Efficiency:** By using a single, generic interface and dynamic configuration, we reduce code duplication and improve efficiency in managing API clients.
- **DRY Principle:** Keeps the codebase clean and avoids repetition.
- **Flexibility:** Easily adapts to new APIs or changes in existing ones without major code refactoring.
- **Resilience:** Leveraging Polly ensures robust handling of API failures, maintaining system stability and performance.

## Why This Approach?

This dynamic, configuration-driven design ensures that we can scale the platform without the overhead of duplicating API client logic. As a result, we’re able to handle diverse endpoints efficiently and with resilience.

## Technologies Used

- **Refit:** A type-safe REST client for .NET.
- **Polly:** A resilience and transient-fault-handling library.

## Example Configuration

```json
{
  "Airlines": [
    {
      "Name": "Airline1",
      "BaseUrl": "https://api.airline1.com",
      "Routes": {
        "SearchFlights": "/flights/search",
        "BookFlight": "/flights/book"
      }
    },
    {
      "Name": "Airline2",
      "BaseUrl": "https://api.airline2.com",
      "Routes": {
        "SearchFlights": "/search",
        "BookFlight": "/book"
      }
    }
  ]
}
