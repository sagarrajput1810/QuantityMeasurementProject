using QuantityMeasurement.Models;

namespace QuantityMeasurement.Repository;

public interface IAuthRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
}
