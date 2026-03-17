using System;
using QuantityMeasurementSystem.Models;
using QuantityMeasurementSystem.Business;
using QuantityMeasurementSystem.Repository;

namespace QuantityMeasurementSystem.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Injecting the new Database Repository instead of the in-memory one
            IMeasurementRepository repo = new MeasurementDatabaseRepository();
            IMeasurementBusiness business = new MeasurementBusiness(repo);

            Console.WriteLine("=== UC16: Quantity Measurement System (Database Persistence) ===\n");

            try
            {
                double inputVal1 = 5.0;
                Unit from1 = Unit.FEET;
                Unit to1 = Unit.INCH;
                
                Console.WriteLine($"Converting {inputVal1} {from1.Name} to {to1.Name}...");
                Quantity result1 = business.Convert(inputVal1, from1, to1);
                Console.WriteLine($"Result: {result1}\n");

                double inputVal2 = 10.0;
                Unit from2 = Unit.KG;
                Unit to2 = Unit.GRAM;
                
                Console.WriteLine($"Converting {inputVal2} {from2.Name} to {to2.Name}...");
                Quantity result2 = business.Convert(inputVal2, from2, to2);
                Console.WriteLine($"Result: {result2}\n");

                Console.WriteLine("--- Conversion History from Database ---");
                var history = business.GetHistory();
                
                foreach (var record in history)
                {
                    Console.WriteLine($"[{record.CreatedAt:yyyy-MM-dd HH:mm:ss}] " +
                                      $"{record.InputValue} {record.FromUnit} -> " +
                                      $"{Math.Round(record.ConvertedValue, 2)} {record.ToUnit}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}