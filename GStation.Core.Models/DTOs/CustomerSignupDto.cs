using GStation.Core.Models.Enums;

namespace GStation.Core.Models.DTOs
{
    public class CustomerSignupDto : UserSignupDto
    {
        public string RFC { get; set; }
        public string BussinessName { get; set; }
        public string NumRegIDTrib { get; set; }
        public decimal CreditLimit { get; set; }
        public MonthDayPaymentEnum MonthDayPayment { get; set; }
        public DeadlineDaysEnum DeadLineDays { get; set; }
        public ModalityEnum Modality { get; set; }
        public ICollection<CustomerAddressSetDto> Addresses { get; set; }
    }
}
