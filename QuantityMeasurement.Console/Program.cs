// File: Program.cs
using QuantityMeasurementSystem.Models;
using QuantityMeasurementSystem.Business;
using QuantityMeasurementSystem.Repository;

namespace QuantityMeasurementSystem.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Manual Dependency Injection (Boilerplate)
            IMeasurementRepository repo = new MeasurementRepository();
            IMeasurementBusiness business = new MeasurementBusiness(repo);

            Console.WriteLine("=== UC15: Quantity Measurement System (N-Tier) ===\n");

            try
            {
                // Scenario: User wants to convert 5 Feet to Inches
                double inputVal = 5.0;
                Unit from = Unit.FEET;
                Unit to = Unit.INCH;

                Quantity result = business.Convert(inputVal, from, to);

                Console.WriteLine($"Input: {inputVal} {from.Name}");
                Console.WriteLine($"Converted Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}