namespace GStation.Core.Models
{
    public class CustomerAddress
    {
        public Guid CustomerId { get; set; }
        public Guid AddressId { get; set; }
        public Customer Customer { get; set; }
        public Address Address { get; set; }
    }
}
