using System.Collections.Generic;
using QuantityMeasurementSystem.Models;

namespace QuantityMeasurementSystem.Business
{
    public interface IMeasurementBusiness
    {
        Quantity Convert(double value, Unit fromUnit, Unit toUnit);
        IEnumerable<ConversionHistoryEntity> GetHistory();
    }
}