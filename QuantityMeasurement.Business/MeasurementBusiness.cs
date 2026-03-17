using System;
using System.Collections.Generic;
using QuantityMeasurementSystem.Models;
using QuantityMeasurementSystem.Repository;

namespace QuantityMeasurementSystem.Business
{
    public class MeasurementBusiness : IMeasurementBusiness
    {
        private readonly IMeasurementRepository _repository;

        public MeasurementBusiness(IMeasurementRepository repository)
        {
            _repository = repository;
        }

        public Quantity Convert(double value, Unit fromUnit, Unit toUnit)
        {
            var quantity = new Quantity(value, fromUnit);
            Quantity result = quantity.ConvertTo(toUnit);

            var historyRecord = new ConversionHistoryEntity
            {
                InputValue = value,
                FromUnit = fromUnit.Name,
                ConvertedValue = result.Value,
                ToUnit = toUnit.Name
            };

            try
            {
                _repository.SaveConversion(historyRecord);
            }
            catch (Exception)
            {
                Console.WriteLine("Warning: Could not save conversion to history.");
            }

            return result;
        }

        public IEnumerable<ConversionHistoryEntity> GetHistory()
        {
            return _repository.GetConversionHistory();
        }
    }
}