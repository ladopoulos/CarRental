using CarRental.Domain.Entities;
using FluentResults;

namespace CarRental.Domain.Strategies;

public class CombiPriceCalculationStrategy : IPriceCalculationStrategy
{
    private const int BaseDayRental = 50;
    private const decimal BaseKmPrice = 0.5m;
    private const decimal Multiplier = 1.3m;

    public Result<decimal> CalculatePrice(Rental rental)
    {
        if (!rental.ReturnDateTime.HasValue || !rental.ReturnMeterReading.HasValue)
        {
            return Result.Fail<decimal>("Car has not been returned yet.");
        }

        var numberOfDays = (rental.ReturnDateTime.Value - rental.PickupDateTime).Days;
        var numberOfKm = rental.ReturnMeterReading - rental.PickupMeterReading;
        var price = BaseDayRental * numberOfDays * Multiplier + BaseKmPrice * numberOfKm;
        
        return Result.Ok((decimal)price!);
    }
}