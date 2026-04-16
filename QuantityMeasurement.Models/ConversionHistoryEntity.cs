// QuantityMeasurement.Models/ConversionHistoryEntity.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace QuantityMeasurement.Models
{
    public class ConversionHistoryEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign Key to User
        public string? Type { get; set; } = "CONVERSION"; // CONVERSION, COMPARISON, OPERATION
        public double InputValue { get; set; }
        public string? FromUnit { get; set; } = string.Empty;
        public double ConvertedValue { get; set; }
        public string? ToUnit { get; set; } = string.Empty;
        public string? Operation { get; set; } // add, sub, mul, div, compare
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}