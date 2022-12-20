using GStation.Core.Models.Enums;
using GStation.Core.Props.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace GStation.Core.Models.DTOs
{
    public class CustomerSignupDto : UserSignupDto
    {
        [StringLength(13, ErrorMessage = "El valor de {0} no puede exeder los {1} caracteres.")]
        public string RFC { get; set; }
        [StringLength(100, ErrorMessage = "El valor de {0} no puede exeder los {1} caracteres.")]
        public string BussinessName { get; set; }
        [StringLength(40, ErrorMessage = "El valor de {0} no puede exeder los {1} caracteres.")]
        public string NumRegIDTrib { get; set; }
        [Range(1000, 1000000, ErrorMessage = "El valor de {0} debe ser entre {1} y {2}.")]
        public decimal CreditLimit { get; set; }
        public MonthDayPaymentEnum MonthDayPayment { get; set; }
        public DeadlineDaysEnum DeadLineDays { get; set; }
        public ModalityEnum Modality { get; set; }
        //[ListCount(1, 5, ErrorMessage = "La cantidad de direcciones debe ser entre 1 y 5")]
        public ICollection<CustomerAddressSetDto> Addresses { get; set; }
    }
}
