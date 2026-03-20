// QuantityMeasurement.Models/ConversionHistoryEntity.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace QuantityMeasurement.Models
{
    public class ConversionHistoryEntity
    {
        [Key]
        public int Id { get; set; }
        public double InputValue { get; set; }
        public string FromUnit { get; set; }
        public double ConvertedValue { get; set; }
        public string ToUnit { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}