using GStation.Core.Models.Enums;

namespace GStation.Core.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string RFC { get; set; }
        public string BusinessName { get; set; }
        public string NumRegIDTrib { get; set; }
        public decimal CreditLimit { get; set; }
        public MonthDayPaymentEnum MonthDayPayment { get; set; }
        public DeadlineDaysEnum DeadLineDays { get; set; }
        public ModalityEnum Modality { get; set; }

        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        public ICollection<CustomerAddress> Addresses { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }

    public static class CustomerExtensions
    {
        public static void RemovePerson(this Customer customer)
        {
            customer.Person = null;
        }
    }

}


