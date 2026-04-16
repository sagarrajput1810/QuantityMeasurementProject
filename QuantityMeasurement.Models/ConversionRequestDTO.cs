// QuantityMeasurement.Models/ConversionRequestDTO.cs
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace QuantityMeasurement.Models
{
    public class ConversionRequestDTO
    {
        [Required(ErrorMessage = "Value is required")]
        [JsonPropertyName("value")]
        public double Value { get; set; }

        [Required(ErrorMessage = "FromUnit is required")]
        [JsonPropertyName("fromUnit")]
        public string FromUnit { get; set; }

        [Required(ErrorMessage = "ToUnit is required")]
        [JsonPropertyName("toUnit")]
        public string ToUnit { get; set; }
    }
}