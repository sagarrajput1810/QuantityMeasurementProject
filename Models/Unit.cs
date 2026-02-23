namespace QuantityMeasurementSystem.Models
{
    public class Unit
    {
        // Static instances jo Enum ki tarah use honge
        public static readonly Unit INCH = new Unit(1.0);
        public static readonly Unit FEET = new Unit(12.0);
        public static readonly Unit YARD = new Unit(36.0);
        public static readonly Unit CM = new Unit(1.0 / 2.54);

        public double ConversionFactor { get; }

        // Private constructor taaki bahar se koi naya Unit na bana sake
        private Unit(double factor)
        {
            ConversionFactor = factor;
        }

        // Ye method Unit khud perform karega
        public double ConvertToBase(double value)
        {
            return value * ConversionFactor;
        }
    }
}