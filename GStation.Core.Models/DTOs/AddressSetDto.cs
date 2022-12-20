using GStation.Core.Props.Constants;
using System.ComponentModel.DataAnnotations;

namespace GStation.Core.Models.DTOs
{
    public class AddressSetDto
    {
        [StringLength(10, ErrorMessage = ValidationConstants.STRING_LENGTH)]
        public string PostalCode { get; set; }
        [StringLength(30, ErrorMessage = ValidationConstants.STRING_LENGTH)]
        public string Street { get; set; }
        [StringLength(50, ErrorMessage = ValidationConstants.STRING_LENGTH)]
        public string Subdivision { get; set; }
        [StringLength(50, ErrorMessage = ValidationConstants.STRING_LENGTH)]
        public string City { get; set; }
        public Guid StateId { get; set; }
    }
}
