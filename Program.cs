using QuantityMeasurementSystem.Models;
using QuantityMeasurementSystem.Enums;

// 1 Foot ko CM mein badal kar dekhte hain
Quantity myFoot = new Quantity(1.0, Unit.FEET);
double resultInCm = myFoot.ConvertTo(Unit.CM);

Console.WriteLine("--- UC 5: Unit Conversion Test ---");
Console.WriteLine($"1 Foot is equal to {resultInCm} CM"); 
// Output: 30.48 CM aana chahiye