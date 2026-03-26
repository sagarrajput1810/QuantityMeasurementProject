using Microsoft.AspNetCore.Mvc;
using QuantityMeasurement.Business;
using QuantityMeasurement.Models;
using QuantityMeasurementSystem.Services;

namespace QuantityMeasurementSystem.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthBusiness _authBusiness;
    private readonly IJwtTokenService _jwtTokenService;

    public AuthController(IAuthBusiness authBusiness, IJwtTokenService jwtTokenService)
    {
        _authBusiness = authBusiness;
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup([FromBody] UserRegisterDTO dto)
    {
        try
        {
            await _authBusiness.RegisterAsync(dto);
            return Ok(new { message = "User registered successfully." });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDTO dto)
    {
        try
        {
            var user = await _authBusiness.ValidateUserAsync(dto);
            var token = _jwtTokenService.CreateToken(user);

            return Ok(new AuthResponseDto
            {
                Token = token,
                Email = user.Email,
                UserName = user.UserName
            });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}
