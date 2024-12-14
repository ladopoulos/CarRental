using CarRental.Domain.Strategies;
using FluentResults;

namespace CarRental.Domain.Entities
{
    public class Rental
    {
        // consider using a value objects
        public Guid Id { get; private set; }
        public string BookingNumber { get; private set; }
        public string RegistrationNumber { get; private set; }
        public string SSN { get; private set; }
        public CarCategory CarCategory { get; private set; }
        public DateTime PickupDateTime { get; private set; }

        public int PickupMeterReading { get; private set; }

        public DateTime? ReturnDateTime { get; private set; }

        public int? ReturnMeterReading { get; private set; }

        public decimal? Price { get; private set; }


        public Rental()
        {
        }

        private Rental(Guid id, string bookingNumber, string registrationNumber, string ssn, CarCategory carCategory,
            DateTime pickupDateTime, int pickupMeterReading)
        {
            Id = id;
            BookingNumber = bookingNumber;
            RegistrationNumber = registrationNumber;
            SSN = ssn;
            CarCategory = carCategory;
            PickupDateTime = pickupDateTime;
            PickupMeterReading = pickupMeterReading;
            ReturnDateTime = null;
            ReturnMeterReading = null;
        }

        public static Result<Rental> Create(string bookingNumber, string registrationNumber, string ssn,
            CarCategory carCategory, DateTime pickupDateTime, int pickupMeterReading)
        {
            return Result.Ok(new Rental(Guid.NewGuid(), bookingNumber, registrationNumber, ssn, carCategory,
                pickupDateTime,
                pickupMeterReading));
        }

        public Result RegisterReturn(DateTime returnDateTime, int returnMeterReading,
            IPriceCalculationStrategy priceCalculationStrategy)
        {
            //todo: write tests for this
            if (ReturnDateTime.HasValue)
            {
                return Result.Fail("Car has already been returned");
            }

            if (returnDateTime < PickupDateTime)
            {
                return Result.Fail("Return date cannot be earlier than pickup date");
            }

            if (returnMeterReading < PickupMeterReading)
            {
                return Result.Fail("Return meter reading cannot be less than pickup reading");
            }

            ReturnDateTime = returnDateTime;
            ReturnMeterReading = returnMeterReading;

            var priceResult = priceCalculationStrategy.CalculatePrice(this);
            if (priceResult.IsFailed)
                return Result.Fail(priceResult.Errors);

            Price = priceResult.Value;

            return Result.Ok();
        }
    }
}