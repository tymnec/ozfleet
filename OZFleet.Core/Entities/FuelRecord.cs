using System;

namespace OZFleet.Core.Entities
{
    public class FuelRecord
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public DateTime FuelDate { get; set; }
        public decimal FuelAmount { get; set; } // Liters or gallons
        public decimal Cost { get; set; }
        public double OdometerReading { get; set; }
    }
}
