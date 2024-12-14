using CarRental.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CarRental.Infrastructure.Persistence.Repositories;

namespace CarRental.Infrastructure.DI;

public static class InfrastructureDependencies
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<CarRentalDbContext>(opt =>
            opt.UseInMemoryDatabase("CarRental"), ServiceLifetime.Singleton); //Don't do this in production :P 


        services.AddTransient<ICarRentalRepository, CarRentalRepository>();
        return services;
    }
}