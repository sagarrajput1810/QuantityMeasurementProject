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

        public override bool Equals(object? obj)
        {
            if (obj is Quantity other)
            {
                if (this.Unit.Type != other.Unit.Type) return false;

                double v1 = this.Unit.ConvertToBase(this.Value);
                double v2 = other.Unit.ConvertToBase(other.Value);
                return Math.Abs(v1 - v2) < 0.001;
            }
            return false;
        }

        public Quantity Add(Quantity other)
        {
            // Security: Prevent adding different dimensions
            if (this.Unit.Type != other.Unit.Type)
            {
                throw new InvalidOperationException($"Cannot add {this.Unit.Type} and {other.Unit.Type}");
            }

            double v1 = this.Unit.ConvertToBase(this.Value);
            double v2 = other.Unit.ConvertToBase(other.Value);
            double totalInBase = v1 + v2;

            // Determine result unit based on type
            Unit resultUnit = this.Unit.Type switch
            {
                Unit.UnitType.LENGTH => Unit.INCH,
                Unit.UnitType.VOLUME => Unit.LITER,
                Unit.UnitType.WEIGHT => Unit.GRAM,
                _ => throw new InvalidOperationException("Unknown Unit Type")
            };

            return new Quantity(totalInBase, resultUnit);
        }

        public override int GetHashCode() => HashCode.Combine(Value, Unit);
    }
}