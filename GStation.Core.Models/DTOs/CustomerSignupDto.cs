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
        [Range(1, 5, ErrorMessage = ValidationConstants.RANGE)]
        public MonthDayPaymentEnum MonthDayPayment { get; set; }
        [Range(1, 3, ErrorMessage = ValidationConstants.RANGE)]
        public DeadlineDaysEnum DeadLineDays { get; set; }
        [Range(1, 3, ErrorMessage = ValidationConstants.RANGE)]
        public ModalityEnum Modality { get; set; }
        public ICollection<AddressSetDto> Addresses { get; set; }
    }
}
