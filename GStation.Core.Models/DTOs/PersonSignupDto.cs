using GStation.Core.Props.Constants;
using System.ComponentModel.DataAnnotations;

namespace GStation.Core.Models.DTOs
{
    public class PersonSignupDto
    {
        [StringLength(50, ErrorMessage = ValidationConstants.STRING_LENGTH)]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = ValidationConstants.STRING_LENGTH)]
        public string PaternalSurname { get; set; }
        [StringLength(50, ErrorMessage = ValidationConstants.STRING_LENGTH)]
        public string MaternalSurname { get; set; }
        [StringLength(15, ErrorMessage = ValidationConstants.STRING_LENGTH)]
        public string PhoneNumber { get; set; }
    }
}
