using GStation.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GStation.Core.Models.DTOs
{
    public class CustomerSignupDto
    {
        public string RFC { get; set; }
        public string BussinessName { get; set; }
        public string NumRegIDTrib { get; set; }
        public decimal CreditLimit { get; set; }
        public MonthDayPaymentEnum MonthDayPayment { get; set; }
        public DeadlineDaysEnum DeadLineDays { get; set; }
        public ModalityEnum Modality { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public PersonSignupDto Person { get; set; }
    }
}
