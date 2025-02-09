namespace OZFleet.Core.Entities
{
    public class Driver
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LicenseNumber { get; private set; }

        // Constructor
        public Driver(int id, string name, string licenseNumber)
        {
            Id = id;
            Name = name;
            LicenseNumber = licenseNumber;
        }

        // Business Logic: Assign a Vehicle to the Driver
        public void AssignVehicle(Vehicle vehicle)
        {
            if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
            vehicle.AssignDriver(this);
        }
    }
}
