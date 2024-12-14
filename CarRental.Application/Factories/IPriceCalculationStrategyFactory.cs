using CarRental.Domain.Entities;
using CarRental.Domain.Strategies;
using FluentResults;

namespace CarRental.Application.Factories;

public interface IPriceCalculationStrategyFactory
{
    Result<IPriceCalculationStrategy> GetStrategy(CarCategory carCategory);
}