using CarRental.Domain.Entities;
using CarRental.Domain.Errors;
using CarRental.Infrastructure.Persistence.Repositories;
using FluentResults;
using MediatR;

namespace CarRental.Application.UseCases.CarPickup;

public class RegisterCarReturnHandler(ICarRentalRepository repository)
    : IRequestHandler<RegisterCarPickupCommand, Result>
{
    public async Task<Result> Handle(RegisterCarPickupCommand request, CancellationToken cancellationToken)
    {
        //todo:write unit tests
        //todo: ensure that the car is available
        var existingRental = await repository.GetByBookingNumber(request.BookingNumber);
        if (existingRental != null)
            return Result.Fail(new DuplicateError($"Booking number '{request.BookingNumber}' already in use"));

        var rental = Rental.Create(request.BookingNumber, request.RegistrationNumber, request.CustomerSsn,
            request.CarCategory, request.PickupDateTime, request.PickupMeterReading);

        if (rental.IsFailed)
            return Result.Fail(rental.Errors);

        try
        {
            await repository.Add(rental.Value);

            return Result.Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}