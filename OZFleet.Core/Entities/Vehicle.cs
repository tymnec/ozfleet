namespace OZFleet.Core.Entities
{
    public class Vehicle
    {
        public int Id { get; private set; }
        public string Model { get; private set; }
        public string RegistrationNumber { get; private set; }
        public Driver AssignedDriver { get; private set; }

        // Constructor
        public Vehicle(int id, string model, string registrationNumber)
        {
            Id = id;
            Model = model;
            RegistrationNumber = registrationNumber;
            AssignedDriver = null;  // Initially no driver assigned
        }

        // Business Logic: Assign Driver to Vehicle
        public void AssignDriver(Driver driver)
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            AssignedDriver = driver;
        }
    }
}
