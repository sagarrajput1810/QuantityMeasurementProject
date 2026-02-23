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

                // Temperature ke liye 0.1 ki precision kaafi hai
                return Math.Abs(v1 - v2) < 0.1;
            }
            return false;
        }

        public Quantity Add(Quantity other)
        {
            // Physics Rule: Temperature add nahi ki jati (10°C + 10°C != 20°C)
            if (this.Unit.Type == Unit.UnitType.TEMPERATURE)
            {
                throw new InvalidOperationException("Addition is not supported for Temperature.");
            }

            if (this.Unit.Type != other.Unit.Type)
            {
                throw new InvalidOperationException($"Cannot add {this.Unit.Type} and {other.Unit.Type}");
            }

            double totalInBase = this.Unit.ConvertToBase(this.Value) + other.Unit.ConvertToBase(other.Value);

            Unit resultUnit = this.Unit.Type switch
            {
                Unit.UnitType.LENGTH => Unit.INCH,
                Unit.UnitType.VOLUME => Unit.LITER,
                Unit.UnitType.WEIGHT => Unit.GRAM,
                _ => throw new InvalidOperationException("Invalid Operation")
            };

            return new Quantity(totalInBase, resultUnit);
        }
    }
}