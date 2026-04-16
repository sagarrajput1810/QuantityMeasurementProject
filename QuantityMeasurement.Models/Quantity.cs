// QuantityMeasurement.Models/Quantity.cs
using System;

namespace QuantityMeasurement.Models
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Quantity other = (Quantity)obj;
            if (this.Unit.Type != other.Unit.Type)
                return false;

            double base1 = this.Unit.ConvertToBase(this.Value);
            double base2 = other.Unit.ConvertToBase(other.Value);
            return Math.Abs(base1 - base2) < 0.001;
        }

        public override int GetHashCode()
        {
            return Unit.Type.GetHashCode();
        }

        public Quantity Add(Quantity other)
        {
            if (this.Unit.Type != other.Unit.Type)
                throw new InvalidOperationException("Cannot add quantities of different types.");

            double baseValue1 = this.Unit.ConvertToBase(this.Value);
            double baseValue2 = other.Unit.ConvertToBase(other.Value);
            double resultBase = baseValue1 + baseValue2;
            double finalValue = (resultBase / this.Unit.ConversionFactor) + this.Unit.Offset;
            return new Quantity(finalValue, this.Unit);
        }

        public Quantity Subtract(Quantity other)
        {
            if (this.Unit.Type != other.Unit.Type)
                throw new InvalidOperationException("Cannot subtract quantities of different types.");

            double baseValue1 = this.Unit.ConvertToBase(this.Value);
            double baseValue2 = other.Unit.ConvertToBase(other.Value);
            double resultBase = baseValue1 - baseValue2;
            double finalValue = (resultBase / this.Unit.ConversionFactor) + this.Unit.Offset;
            return new Quantity(finalValue, this.Unit);
        }

        public Quantity Multiply(double factor)
        {
            return new Quantity(this.Value * factor, this.Unit);
        }

        public Quantity Divide(double divisor)
        {
            if (divisor == 0) throw new DivideByZeroException();
            return new Quantity(this.Value / divisor, this.Unit);
        }

        public override string ToString() => $"{Math.Round(Value, 2)} {Unit.Name}";
    }
}