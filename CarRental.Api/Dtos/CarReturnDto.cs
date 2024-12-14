namespace CarRental.Api.Dtos
{
    public class CarReturnDto
    {
        public DateTime ReturnDateTime { get; set; }
        public int ReturnMeterReading { get; set; }
    }
}