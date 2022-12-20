using GStation.Core.Models.Enums;
using System.ComponentModel.DataAnnotations;
using GStation.Core.Props.Constants;

namespace GStation.Core.Models.DTOs
{
    public class CustomerSignupDto : UserSignupDto
    {
        [StringLength(13, ErrorMessage = ValidationConstants.STRING_LENGTH)]
        public string RFC { get; set; }
        [StringLength(100, ErrorMessage = ValidationConstants.STRING_LENGTH)]
        public string BusinessName { get; set; }
        [StringLength(40, ErrorMessage = ValidationConstants.STRING_LENGTH)]
        public string NumRegIDTrib { get; set; }
        public MonthDayPaymentEnum MonthDayPayment { get; set; }
        public DeadlineDaysEnum DeadLineDays { get; set; }
        public ModalityEnum Modality { get; set; }
        public ICollection<CustomerAddressSetDto> Addresses { get; set; }
    }
}
