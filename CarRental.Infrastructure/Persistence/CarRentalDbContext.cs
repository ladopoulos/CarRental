using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Persistence;

public class CarRentalDbContext : DbContext
{
    public DbSet<Rental> Rentals { get; set; }

    public CarRentalDbContext()
    {
    }

    public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rental>()
            .HasKey(r => r.Id);
    }
}