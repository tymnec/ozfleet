namesapace OZFleet.Core.Entities
{
    public class Fleet
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<Vehicle> Vehicles { get; private set; }
}

// Constructor
public Fleet(int id, string name)
{
    Id = id;
    Name = name;
    Vehicles = new List<Vehicle>();
}

// Business Logic: Add Vehicle to Fleet
public void AddVehicle(Vehicle vehicle)
{
    if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
    Vehicles.Add(vehicle);
}

// Business Logic: Remove Vehicle from Fleet
{
    if (vehicle == null) throw new ArgumentNullException(nameof(vehicle));
    Vehicles.Remove(vehicle);
}
}