// QuantityMeasurement.Models/ConversionRequestDTO.cs
using System.ComponentModel.DataAnnotations;

namespace QuantityMeasurement.Models
{
    public class ConversionRequestDTO
    {
        [Required(ErrorMessage = "Value is required")]
        public double Value { get; set; }

        [Required(ErrorMessage = "FromUnit is required")]
        public string FromUnit { get; set; }

        [Required(ErrorMessage = "ToUnit is required")]
        public string ToUnit { get; set; }
    }
}