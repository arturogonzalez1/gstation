namespace GStation.Core.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Plate { get; set; }
        public string Year { get; set; }
        public string Brand { get; set; }
        public string VIN { get; set; }

        public Guid CustomerId { get; set; }
        public Manager Customer { get; set; }
    }
}
