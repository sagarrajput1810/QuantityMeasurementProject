using System.Text.Json.Serialization;

namespace QuantityMeasurement.Models
{
    public class ComparisonRequestDTO
    {
        [JsonPropertyName("value1")]
        public double Value1 { get; set; }

        [JsonPropertyName("unit1")]
        public string Unit1 { get; set; } = string.Empty;

        [JsonPropertyName("value2")]
        public double Value2 { get; set; }

        [JsonPropertyName("unit2")]
        public string Unit2 { get; set; } = string.Empty;
    }
}