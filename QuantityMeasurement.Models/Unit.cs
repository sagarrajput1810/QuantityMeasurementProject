using System;

namespace QuantityMeasurementSystem.Models
{
    public class Unit
    {
        public enum UnitType { LENGTH, VOLUME, WEIGHT, TEMPERATURE }

        public static readonly Unit INCH = new Unit(1.0, UnitType.LENGTH, "INCH");
        public static readonly Unit FEET = new Unit(12.0, UnitType.LENGTH, "FEET");
        public static readonly Unit YARD = new Unit(36.0, UnitType.LENGTH, "YARD");
        public static readonly Unit CM = new Unit(1.0 / 2.54, UnitType.LENGTH, "CM");
        public static readonly Unit LITER = new Unit(1.0, UnitType.VOLUME, "LITER");
        public static readonly Unit GALLON = new Unit(3.78541, UnitType.VOLUME, "GALLON");
        public static readonly Unit ML = new Unit(0.001, UnitType.VOLUME, "ML");
        public static readonly Unit GRAM = new Unit(1.0, UnitType.WEIGHT, "GRAM");
        public static readonly Unit KG = new Unit(1000.0, UnitType.WEIGHT, "KG");
        public static readonly Unit TONNE = new Unit(1000000.0, UnitType.WEIGHT, "TONNE");
        public static readonly Unit CELSIUS = new Unit(1.0, UnitType.TEMPERATURE, "CELSIUS", 0);
        public static readonly Unit FAHRENHEIT = new Unit(5.0 / 9.0, UnitType.TEMPERATURE, "FAHRENHEIT", 32);

        public double ConversionFactor { get; }
        public double Offset { get; }
        public UnitType Type { get; }
        public string Name { get; }

        private Unit(double factor, UnitType type, string name, double offset = 0)
        {
            ConversionFactor = factor;
            Type = type;
            Name = name;
            Offset = offset;
        }

        public double ConvertToBase(double value) => (value - Offset) * ConversionFactor;
    }
}