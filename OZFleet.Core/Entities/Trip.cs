using System;

namespace OZFleet.Core.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public double Distance { get; set; } // In kilometers or miles
    }
}
