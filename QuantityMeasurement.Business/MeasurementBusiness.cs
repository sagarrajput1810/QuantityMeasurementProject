using System;
using System.Collections.Generic;
using System.Linq;
using QuantityMeasurement.Models;
using QuantityMeasurement.Repository;

namespace QuantityMeasurement.Business
{
    public class MeasurementBusiness : IMeasurementBusiness
    {
        private readonly IMeasurementRepository _repository;

        public MeasurementBusiness(IMeasurementRepository repository)
        {
            _repository = repository;
        }

        public Quantity Convert(double value, Unit fromUnit, Unit toUnit, int userId)
        {
            var quantity = new Quantity(value, fromUnit);
            Quantity result = quantity.ConvertTo(toUnit);

            SaveToHistory(userId, "CONVERSION", value, fromUnit.Name, result.Value, toUnit.Name);
            return result;
        }

        public IEnumerable<ConversionHistoryEntity> GetHistory(int userId)
        {
            try
            {
                return _repository.GetConversionHistory(userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DB Error: {ex.Message}");
                return new List<ConversionHistoryEntity>();
            }
        }

        public bool Compare(double val1, Unit unit1, double val2, Unit unit2, int userId)
        {
            var q1 = new Quantity(val1, unit1);
            var q2 = new Quantity(val2, unit2);
            bool isEqual = q1.Equals(q2);
            
            SaveToHistory(userId, "COMPARISON", val1, unit1.Name, val2, unit2.Name, "compare");
            return isEqual;
        }

        public Quantity PerformOperation(double val1, Unit unit1, double val2, Unit? unit2, string operation, int userId)
        {
            var q1 = new Quantity(val1, unit1);
            Quantity result;
            string op = operation.ToLower();

            switch (op)
            {
                case "add":
                    result = q1.Add(new Quantity(val2, unit2!));
                    break;
                case "sub":
                    result = q1.Subtract(new Quantity(val2, unit2!));
                    break;
                case "mul":
                    result = q1.Multiply(val2);
                    break;
                case "div":
                    result = q1.Divide(val2);
                    break;
                default:
                    throw new InvalidOperationException($"Unsupported operation: {operation}");
            }

            SaveToHistory(userId, "OPERATION", val1, unit1.Name, result.Value, result.Unit.Name, op);
            return result;
        }

        public void DeleteHistory(int userId)
        {
            _repository.DeleteAllHistory(userId);
        }

        private void SaveToHistory(int userId, string type, double val1, string unit1, double val2, string unit2, string? op = null)
        {
            try
            {
                var historyRecord = new ConversionHistoryEntity
                {
                    UserId = userId,
                    Type = type,
                    InputValue = val1,
                    FromUnit = unit1,
                    ConvertedValue = val2,
                    ToUnit = unit2,
                    Operation = op
                };
                _repository.SaveConversion(historyRecord);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Could not save to history. Error: {ex.Message}");
            }
        }
    }
}