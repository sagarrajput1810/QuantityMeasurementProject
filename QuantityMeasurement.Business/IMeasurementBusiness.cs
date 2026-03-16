// File: IMeasurementBusiness.cs
using QuantityMeasurementSystem.Models;

// File: MeasurementBusiness.cs
using QuantityMeasurementSystem.Repository;


namespace QuantityMeasurementSystem.Business
{
    public interface IMeasurementBusiness
    {
        Quantity Convert(double value, Unit fromUnit, Unit toUnit);
    }

    

    public class MeasurementBusiness : IMeasurementBusiness
    {
        private readonly IMeasurementRepository _repository;

        public MeasurementBusiness(IMeasurementRepository repository)
        {
            _repository = repository;
        }

        public Quantity Convert(double value, Unit fromUnit, Unit toUnit)
        {
            // Logic: Create quantity and call model conversion
            var quantity = new Quantity(value, fromUnit);
            return quantity.ConvertTo(toUnit);
        }
    }
}