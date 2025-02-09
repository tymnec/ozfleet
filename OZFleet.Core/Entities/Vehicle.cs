namespace OZFleet.Core.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }    // e.g. Toyota
        public string Model { get; set; }   // e.g. Camry
        public int Year { get; set; }
    }
}
