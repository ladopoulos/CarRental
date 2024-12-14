using CarRental.Domain.Entities;
using CarRental.Domain.Strategies;
using FluentResults;

namespace CarRental.Application.Factories;

public class PriceCalculationStrategyFactory : IPriceCalculationStrategyFactory
{
    public Result<IPriceCalculationStrategy> GetStrategy(CarCategory carCategory)
    {
        return carCategory switch
        {
            CarCategory.Small => new SmallCarPriceCalculationStrategy(),
            CarCategory.Combi => new CombiPriceCalculationStrategy(),
            CarCategory.Truck => new TruckPriceCalculationStrategy(),
            _ => Result.Fail($"Could not found price strategy for car category '{nameof(carCategory)}'")
        };
    }
}