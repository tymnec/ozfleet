using System;

namespace OZFleet.Core.Entities
{
    public class Maintenance
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public DateTime? NextDueDate { get; set; }
    }
}
