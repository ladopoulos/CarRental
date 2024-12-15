# CarRental System

## Overview
The CarRental System is designed to manage car rentals, including booking, returning, and calculating rental prices based on car categories. 

## Architecture
This project follows Clean Architecture principles and uses the CQRS pattern. The solution is divided into:

- Domain layer contains business logic
- Application layer handles use cases
- Infrastructure layer for data access and external services
- API layer is the entry point to our system, and provides REST API endpoints

The solution is not yet complete:
- UI is missing
- Validations are missing
- Extensive testing needs to be implemented
- Actual data storage is missing

## Technologies
- .NET 8
- mediatR
- Entity Framework Core
- FluentResults
- EF Core in-memory database

## Getting Started
### Prerequisites
- .NET 8 SDK
- Visual Studio 2022 or later

## Usage
1. Clone the repository
2. Open the solution in Visual Studio 
3. Run the project (F5)
4. The API will be available at `https://localhost:5089`

To explore the API and its functionality:
- Use Swagger UI at `https://localhost:5089/swagger/index.html`

## API Endpoints

### Rentals

- POST /api/carRental - Book a car
- POST /api/carRental/{bookingNumber}/return -  Return a car
- GET /api/carRental/{bookingNumber} - Get details of a specific rental by booking number

## Discussion Points
- Prices are hard coded based on car categories. How to handle price configuration changes.
- How to handle car availability and booking conflicts.
- How to handle concurrent bookings for the same car.




