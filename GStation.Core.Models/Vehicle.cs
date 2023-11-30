namespace GStation.Core.Models
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Plate { get; set; }
        public string Year { get; set; }
        public string Brand { get; set; }
        public string VIN { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
