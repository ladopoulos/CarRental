using System.Reflection;
using CarRental.Application.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Application.DI;

public static class ApplicationDependencies
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddScoped<IPriceCalculationStrategyFactory, PriceCalculationStrategyFactory>();
        return services;
    }
}