using QuantityMeasurementSystem.Models;
using QuantityMeasurementSystem.Enums;
// Do alag objects banaye same value ke
Quantity q1 = new Quantity(1.0,Unit.FEET);
Quantity q2 = new Quantity(12.0, Unit.INCH);

// Check if they are equal
bool result = q1.Equals(q2);

Console.WriteLine("--- UC 1: Feet Equality Test ---");
Console.WriteLine($"Are 1.0 feet and 12.0 inch equal? {result}");