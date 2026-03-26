using QuantityMeasurement.Models;

namespace QuantityMeasurement.Business;

public interface IAuthBusiness
{
    Task RegisterAsync(UserRegisterDTO dto);
    Task<User> ValidateUserAsync(UserLoginDTO dto);
}
