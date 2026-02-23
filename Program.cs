using QuantityMeasurementSystem.Models;
using QuantityMeasurementSystem.Enums;

// UC 6: 2 Inches + 2 Inches = 4 Inches
Quantity q1 = new Quantity(2.0, Unit.INCH);
Quantity q2 = new Quantity(2.0, Unit.INCH);

Quantity result = q1.Add(q2);

Console.WriteLine("--- UC 6: Addition Test ---");
Console.WriteLine($"2 Inches + 2 Inches = {result.Value} {result.Unit}");
// Output: 4 INCH