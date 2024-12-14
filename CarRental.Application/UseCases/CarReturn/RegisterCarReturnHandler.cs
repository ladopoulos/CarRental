using CarRental.Application.Factories;
using CarRental.Domain.Errors;
using CarRental.Infrastructure.Persistence.Repositories;
using FluentResults;
using MediatR;

namespace CarRental.Application.UseCases.CarReturn;

public class RegisterCarReturnHandler(
    ICarRentalRepository repository,
    IPriceCalculationStrategyFactory priceCalculationStrategyFactory)
    : IRequestHandler<RegisterCarReturnCommand, Result>
{
    public async Task<Result> Handle(RegisterCarReturnCommand command, CancellationToken cancellationToken) //todo: write test
    {
        try
        {
            var rental = await repository.GetByBookingNumber(command.BookingNumber);
            if (rental == null)
                return Result.Fail(new NotFoundError($"Rental with BookingNumber {command.BookingNumber} not fount!"));

            var prisCalculationStrategy = priceCalculationStrategyFactory.GetStrategy(rental.CarCategory);

            if (prisCalculationStrategy.IsFailed)
                return Result.Fail(prisCalculationStrategy.Errors);

            rental.RegisterReturn(command.ReturnDateTime, command.ReturnMeterReading, prisCalculationStrategy.Value);

            return Result.Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}