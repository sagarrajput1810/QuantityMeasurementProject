using QuantityMeasurementSystem.Models;
using QuantityMeasurementSystem.Enums;

Quantity oneYard = new Quantity(1.0, Unit.YARD);
Quantity thirtySixInches = new Quantity(36.0, Unit.INCH);

Console.WriteLine($"Is 1 Yard == 36 Inches? {oneYard.Equals(thirtySixInches)}"); 
// Output: True