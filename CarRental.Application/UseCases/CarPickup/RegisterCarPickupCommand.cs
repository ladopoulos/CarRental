using CarRental.Domain.Entities;
using FluentResults;
using MediatR;

namespace CarRental.Application.UseCases.CarPickup;

public record RegisterCarPickupCommand(
    string BookingNumber,
    string RegistrationNumber,
    string CustomerSsn,
    CarCategory CarCategory,
    DateTime PickupDateTime,
    int PickupMeterReading) : IRequest<Result>;