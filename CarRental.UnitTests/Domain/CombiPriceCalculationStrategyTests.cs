using CarRental.Domain.Entities;
using CarRental.Domain.Strategies;

namespace CarRental.UnitTests.Domain;

public class CombiPriceCalculationStrategyTests
{
    private readonly CombiPriceCalculationStrategy _strategy;

    public CombiPriceCalculationStrategyTests()
    {
        _strategy = new CombiPriceCalculationStrategy();
    }

    [Fact]
    public void GivenRentalNotReturned_WhenCalculatePrice_ThenReturnFailure()
    {
        var rental = Rental.Create("123", "ABC123", "1234567890", CarCategory.Small, DateTime.Now, 1000).Value;

        var result = _strategy.CalculatePrice(rental);

        Assert.True(result.IsFailed);
        Assert.Equal("Car has not been returned yet.", result.Errors.First().Message);
    }

    [Fact]
    public void Given_RentalReturned_When_CalculatePrice_Should_ReturnCorrectPrice()
    {
        var rental = Rental.Create("123", "ABC123", "1234567890", CarCategory.Small, DateTime.Now, 1000).Value;
        rental.RegisterReturn(DateTime.Now.AddDays(3), 2000, _strategy);

        var result = _strategy.CalculatePrice(rental);

        Assert.True(result.IsSuccess);
        Assert.Equal(695, result.Value);
    }
}