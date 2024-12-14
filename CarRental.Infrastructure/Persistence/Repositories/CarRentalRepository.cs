using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Persistence.Repositories;

public interface ICarRentalRepository //todo: move
{
    Task Add(Rental entity);
    Task<Rental?> GetByBookingNumber(string bookingNumber);
}

public class CarRentalRepository(CarRentalDbContext context) : ICarRentalRepository
{
    public async Task Add(Rental rental)
    {
        context.Rentals.Add(rental);

        await context.SaveChangesAsync();
    }

    public async Task<Rental?> GetByBookingNumber(string bookingNumber)
    {
        return await context.Rentals.FirstOrDefaultAsync(r => r.BookingNumber.Equals(bookingNumber));
    }
}