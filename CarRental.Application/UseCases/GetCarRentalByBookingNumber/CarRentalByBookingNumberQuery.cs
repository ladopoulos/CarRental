using CarRental.Domain.Entities;
using FluentResults;
using MediatR;

namespace CarRental.Application.UseCases.GetCarRentalByBookingNumber;

public record CarRentalByBookingNumberQuery(string BookingNumber) : IRequest<Result<Rental>>;