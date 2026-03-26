// QuantityMeasurementSystem/Controllers/MeasurementController.cs
using System;
using Microsoft.AspNetCore.Mvc;
using QuantityMeasurement.Business;
using QuantityMeasurement.Models;
using Microsoft.AspNetCore.Authorization;

namespace QuantityMeasurementSystem.Controllers
{
    [ApiController]
    [Route("api/v1/measurements")]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementBusiness _business;

        public MeasurementController(IMeasurementBusiness business)
        {
            _business = business;
        }

        [HttpPost("convert")]
        public IActionResult Convert([FromBody] ConversionRequestDTO request)
        {
            try
            {
                Unit fromUnit = GetUnitByName(request.FromUnit);
                Unit toUnit = GetUnitByName(request.ToUnit);

                if (fromUnit == null || toUnit == null)
                {
                    return BadRequest(new 
                    { 
                        timestamp = DateTime.UtcNow.ToString("o"),
                        status = 400,
                        error = "Bad Request",
                        message = "Invalid unit specified.",
                        path = HttpContext.Request.Path.Value
                    });
                }

                var result = _business.Convert(request.Value, fromUnit, toUnit);
                
                return Ok(new 
                { 
                    OriginalValue = request.Value, 
                    OriginalUnit = request.FromUnit, 
                    ConvertedValue = Math.Round(result.Value, 2), 
                    ConvertedUnit = request.ToUnit 
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new 
                { 
                    timestamp = DateTime.UtcNow.ToString("o"),
                    status = 400,
                    error = "Quantity Measurement Error",
                    message = ex.Message,
                    path = HttpContext.Request.Path.Value
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new 
                { 
                    timestamp = DateTime.UtcNow.ToString("o"),
                    status = 500,
                    error = "Internal Server Error",
                    message = ex.Message,
                    path = HttpContext.Request.Path.Value
                });
            }
        }

        [Authorize]
        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            try
            {
                var history = _business.GetHistory();
                return Ok(history);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        private Unit GetUnitByName(string unitName)
        {
            return unitName.ToUpper() switch
            {
                "INCH" => Unit.INCH,
                "FEET" => Unit.FEET,
                "YARD" => Unit.YARD,
                "CM" => Unit.CM,
                "LITER" => Unit.LITER,
                "GALLON" => Unit.GALLON,
                "ML" => Unit.ML,
                "GRAM" => Unit.GRAM,
                "KG" => Unit.KG,
                "TONNE" => Unit.TONNE,
                "CELSIUS" => Unit.CELSIUS,
                "FAHRENHEIT" => Unit.FAHRENHEIT,
                _ => null
            };
        }
    }
}