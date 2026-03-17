using System;

namespace QuantityMeasurementSystem.Models
{
    public class Quantity
    {
        public double Value { get; }
        public Unit Unit { get; }

        public Quantity(double value, Unit unit)
        {
            Value = value;
            Unit = unit;
        }

        public Quantity ConvertTo(Unit targetUnit)
        {
            if (this.Unit.Type != targetUnit.Type)
                throw new InvalidOperationException($"Cannot convert {this.Unit.Name} to {targetUnit.Name}");

            double baseValue = this.Unit.ConvertToBase(this.Value);
            double convertedValue = (baseValue / targetUnit.ConversionFactor) + targetUnit.Offset;
            return new Quantity(convertedValue, targetUnit);
        }

        public override string ToString() => $"{Math.Round(Value, 2)} {Unit.Name}";
    }
}