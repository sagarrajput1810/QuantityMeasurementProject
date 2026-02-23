using System;

namespace QuantityMeasurementSystem.Models
{
    public class Quantity : IComparable<Quantity>
    {
        public double Value { get; }
        public Unit Unit { get; }

        public Quantity(double value, Unit unit)
        {
            Value = value;
            Unit = unit;
        }

        // UC 1-11: Equality Logic
        public override bool Equals(object? obj)
        {
            if (obj is Quantity other)
            {
                if (this.Unit.Type != other.Unit.Type) return false;
                return Math.Abs(this.Unit.ConvertToBase(this.Value) - 
                                other.Unit.ConvertToBase(other.Value)) < 0.1;
            }
            return false;
        }

        // UC 12: Comparison Logic (Greater Than / Less Than)
        public int CompareTo(Quantity? other)
        {
            if (other == null) return 1;
            if (this.Unit.Type != other.Unit.Type)
                throw new InvalidOperationException("Cannot compare different types.");

            double v1 = this.Unit.ConvertToBase(this.Value);
            double v2 = other.Unit.ConvertToBase(other.Value);

            if (Math.Abs(v1 - v2) < 0.001) return 0;
            return v1 > v2 ? 1 : -1;
        }

        // UC 6-10: Addition Logic
        public Quantity Add(Quantity other)
        {
            if (this.Unit.Type == Unit.UnitType.TEMPERATURE)
                throw new InvalidOperationException("Temperature addition not supported.");

            if (this.Unit.Type != other.Unit.Type)
                throw new InvalidOperationException("Cannot add different dimensions.");

            double total = this.Unit.ConvertToBase(this.Value) + other.Unit.ConvertToBase(other.Value);

            Unit baseUnit = this.Unit.Type switch {
                Unit.UnitType.LENGTH => Unit.INCH,
                Unit.UnitType.VOLUME => Unit.LITER,
                Unit.UnitType.WEIGHT => Unit.GRAM,
                _ => throw new Exception("Invalid Type")
            };

            return new Quantity(total, baseUnit);
        }

        public override int GetHashCode() => HashCode.Combine(Value, Unit);
    }
}