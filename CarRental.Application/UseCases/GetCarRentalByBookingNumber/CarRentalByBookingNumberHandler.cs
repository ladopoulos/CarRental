using CarRental.Domain.Entities;
using CarRental.Domain.Errors;
using CarRental.Infrastructure.Persistence.Repositories;
using FluentResults;
using MediatR;

namespace CarRental.Application.UseCases.GetCarRentalByBookingNumber;

public class CarRentalByBookingNumberHandler(ICarRentalRepository repository)
    : IRequestHandler<CarRentalByBookingNumberQuery, Result<Rental>>
{
    public async Task<Result<Rental>> Handle(CarRentalByBookingNumberQuery query, CancellationToken cancellationToken)
    {
        try
        {
            var rental = await repository.GetByBookingNumber(query.BookingNumber);

            return rental == null
                ? Result.Fail(new NotFoundError($"Rental with BookingNumber {query.BookingNumber} not fount!"))
                : Result.Ok(rental);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}