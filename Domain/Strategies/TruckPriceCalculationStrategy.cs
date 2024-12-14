using System.Diagnostics;
using CarRental.Domain.Entities;
using FluentResults;

namespace CarRental.Domain.Strategies;

public class TruckPriceCalculationStrategy : IPriceCalculationStrategy
{
    private const int BaseDayRental = 60;
    private const decimal BaseKmPrice = 0.6m;
    private const decimal Multiplier = 1.5m;

    public Result<decimal> CalculatePrice(Rental rental)
    {
        if (!rental.ReturnDateTime.HasValue || !rental.ReturnMeterReading.HasValue)
        {
            return Result.Fail<decimal>("Car has not been returned yet.");
        }

        var numberOfDays = (rental.ReturnDateTime.Value - rental.PickupDateTime).Days;
        var numberOfKm = rental.ReturnMeterReading.Value - rental.PickupMeterReading;

        var price = BaseDayRental * numberOfDays * Multiplier + BaseKmPrice * numberOfKm * Multiplier;
        return Result.Ok(price);
    }
}