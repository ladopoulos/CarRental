using CarRental.Domain.Entities;
using FluentResults;

namespace CarRental.Domain.Strategies;

public interface IPriceCalculationStrategy
{
    Result<decimal> CalculatePrice(Rental rental);
}