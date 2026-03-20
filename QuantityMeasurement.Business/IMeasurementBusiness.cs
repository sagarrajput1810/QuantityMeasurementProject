// QuantityMeasurement.Business/IMeasurementBusiness.cs
using System.Collections.Generic;
using QuantityMeasurement.Models;

namespace QuantityMeasurement.Business
{
    public interface IMeasurementBusiness
    {
        Quantity Convert(double value, Unit fromUnit, Unit toUnit);
        IEnumerable<ConversionHistoryEntity> GetHistory();
    }
}