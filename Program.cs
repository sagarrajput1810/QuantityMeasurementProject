using QuantityMeasurementSystem.Models;
// Ye line bilkul pehle jaisi hi hai, lekin ab ye "Smart Unit" use kar rahi hai
Quantity q1 = new Quantity(1.0, Unit.FEET); 
Quantity q2 = new Quantity(12.0, Unit.INCH);

Console.WriteLine(q1.Equals(q2)); // Output: True