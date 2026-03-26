using QuantityMeasurement.Models;

namespace QuantityMeasurementSystem.Services;

public interface IJwtTokenService
{
    string CreateToken(User user);
}
