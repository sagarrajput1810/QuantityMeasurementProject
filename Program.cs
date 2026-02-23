using QuantityMeasurementSystem.Models;

try 
{
    Console.WriteLine("--- UC 9: Volume Testing ---");
    
    // 1 Gallon == 3.785 Liters
    Quantity gallon = new Quantity(1.0, Unit.GALLON);
    Quantity liters = new Quantity(3.78541, Unit.LITER);
    Console.WriteLine($"Is 1 Gallon == 3.785 Liters? {gallon.Equals(liters)}");

    // 1 Liter + 1000 ML = 2 Liters
    Quantity l1 = new Quantity(1.0, Unit.LITER);
    Quantity ml1000 = new Quantity(1000.0, Unit.ML);
    Quantity total = l1.Add(ml1000);
    Console.WriteLine($"1 Liter + 1000 ML = {total.Value} Liters");

    Console.WriteLine("\n--- Cross-Dimension Security Test ---");
    // Invalid: Feet + Liter (Should throw error)
    Quantity feet = new Quantity(1.0, Unit.FEET);
    feet.Add(l1); 
}
catch (Exception ex)
{
    Console.WriteLine($"Expected Error: {ex.Message}");
}