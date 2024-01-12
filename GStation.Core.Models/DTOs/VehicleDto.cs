namespace GStation.Core.Models.DTOs
{
    public class VehicleDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Plate { get; set; }
        public string Year { get; set; }
        public string Brand { get; set; }
        public string VIN { get; set; }
    }
}
