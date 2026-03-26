using System.Security.Cryptography;
using QuantityMeasurement.Models;
using QuantityMeasurement.Repository;

namespace QuantityMeasurement.Business;

public class AuthBusiness : IAuthBusiness
{
    private readonly IAuthRepository _repository;

    public AuthBusiness(IAuthRepository repository)
    {
        _repository = repository;
    }

    public async Task RegisterAsync(UserRegisterDTO dto)
    {
        var email = dto.Email.Trim().ToLowerInvariant();

        var existingUser = await _repository.GetByEmailAsync(email);
        if (existingUser != null)
        {
            throw new InvalidOperationException("Email already exists.");
        }

        var salt = RandomNumberGenerator.GetBytes(16);

        var hash = Rfc2898DeriveBytes.Pbkdf2(
            dto.Password,
            salt,
            100_000,
            HashAlgorithmName.SHA512,
            32);

        var user = new User
        {
            UserName = dto.UserName.Trim(),
            Email = email,
            PasswordSalt = salt,
            PasswordHash = hash
        };

        await _repository.AddAsync(user);
    }

    public async Task<User> ValidateUserAsync(UserLoginDTO dto)
    {
        var email = dto.Email.Trim().ToLowerInvariant();

        var user = await _repository.GetByEmailAsync(email);
        if (user == null)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var incomingHash = Rfc2898DeriveBytes.Pbkdf2(
            dto.Password,
            user.PasswordSalt,
            100_000,
            HashAlgorithmName.SHA512,
            32);

        var isValid = CryptographicOperations.FixedTimeEquals(
            incomingHash,
            user.PasswordHash);

        if (!isValid)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        return user;
    }
}
