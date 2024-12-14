using FluentResults;
using MediatR;

namespace CarRental.Application.UseCases.CarReturn;

public record RegisterCarReturnCommand(string BookingNumber, DateTime ReturnDateTime, int ReturnMeterReading)
    : IRequest<Result>;