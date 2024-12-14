# CarRental System

## Overview
The CarRental System is designed to manage car rentals, including booking, returning, and calculating rental prices based on car categories. 

The solution is built using C# and targets .NET 8.
This project implements a car rental system using ASP.NET Core Web API with MediatR for implementing the CQRS pattern.

## Architecture
This project follows Clean Architecture principles:
- Domain layer contains business logic
- Application layer handles use cases
- Infrastructure layer for data access and external services
- API layer provides RESTful endpoints

The solution is not yet complete:
- UI is missing
- Extensive testing needs to be implemented

## Getting Started
### Prerequisites
- .NET 8 SDK
- Visual Studio 2022 or later

## Usage
To explore the API and its functionality:
- Use Swagger UI at `/swagger/index.html`

## API Endpoints

### Car Categories
- GET /api/categories - Get all car categories
- POST /api/categories - Create a new car category

### Rentals
- GET /api/rentals - Get all rentals
- POST /api/rentals - Book a car
- GET /api/rentals/{id} - Get details of a specific rental
- PUT /api/rentals/{id} - Update a rental
- DELETE /api/rentals/{id} - Cancel a rental
