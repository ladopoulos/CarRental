using CarRental.Application.Factories;
using CarRental.Domain.Entities;
using CarRental.Domain.Strategies;

namespace CarRental.UnitTests;

public class PriceCalculationStrategyFactoryTests
{
    private readonly PriceCalculationStrategyFactory _factory = new();


    [Theory]
    [MemberData(nameof(GetCarCategories))]
    public void GetStrategy_ShouldReturnExpectedStrategy_WhenCarCategoryIsProvided(CarCategory carCategory,
        Type expectedType, bool isSuccess, string expectedErrorMessage)
    {
        var result = _factory.GetStrategy(carCategory);

        Assert.Equal(isSuccess, result.IsSuccess);
        if (isSuccess)
        {
            Assert.IsType(expectedType, result.Value);
        }
        else
        {
            Assert.Equal(expectedErrorMessage, result.Errors.First().Message);
        }
    }

    public static IEnumerable<object[]> GetCarCategories()
    {
        yield return [CarCategory.Small, typeof(SmallCarPriceCalculationStrategy), true, null];
        yield return [CarCategory.Combi, typeof(CombiPriceCalculationStrategy), true, null];
        yield return [CarCategory.Truck, typeof(TruckPriceCalculationStrategy), true, null];
        yield return [(CarCategory)999, null, false, "Could not found price strategy for car category 'carCategory'"];
    }
}