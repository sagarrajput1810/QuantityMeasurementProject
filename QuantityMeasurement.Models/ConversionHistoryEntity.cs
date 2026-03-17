using System;

namespace QuantityMeasurementSystem.Models
{
    public class ConversionHistoryEntity
    {
        public int Id { get; set; }
        public double InputValue { get; set; }
        public string FromUnit { get; set; }
        public double ConvertedValue { get; set; }
        public string ToUnit { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}