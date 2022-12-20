namespace GStation.Core.Models.DTOs
{
    public class AddressSetDto
    {
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Subdivision { get; set; }
        public string City { get; set; }
        public Guid StateId { get; set; }
    }
}
