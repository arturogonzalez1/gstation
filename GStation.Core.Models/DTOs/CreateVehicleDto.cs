namespace GStation.Core.Models.DTOs
{
    public class CreateVehicleDto
    {
        public string Descripcion { get; set; }
        public string Plate { get; set; }
        public string Year { get; set; }
        public string Brand { get; set; }
        public string VIN { get; set; }

        public Guid CustomerId { get; set; }
    }
}
