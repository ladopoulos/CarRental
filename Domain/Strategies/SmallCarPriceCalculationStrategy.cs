using CarRental.Domain.Entities;
using FluentResults;

namespace CarRental.Domain.Strategies;

public class SmallCarPriceCalculationStrategy : IPriceCalculationStrategy
{
    private const int BaseDayRental = 50; //todo: move to configuration


    public Result<decimal> CalculatePrice(Rental rental)
    {
        if (!rental.ReturnDateTime.HasValue || !rental.ReturnMeterReading.HasValue)
        {
            return Result.Fail<decimal>("Car has not been returned yet.");
        }

        var numberOfDays = (rental.ReturnDateTime.Value - rental.PickupDateTime).Days;

        var price = BaseDayRental * numberOfDays;
        return Result.Ok((decimal)price);
    }
}