// QuantityMeasurementSystem/Controllers/MeasurementController.cs
using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using QuantityMeasurement.Business;
using QuantityMeasurement.Models;
using Microsoft.AspNetCore.Authorization;

namespace QuantityMeasurementSystem.Controllers
{
    [ApiController]
    [Route("api/v1/measurements")]
    [Authorize] // Require token for all measurement actions
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementBusiness _business;

        public MeasurementController(IMeasurementBusiness business)
        {
            _business = business;
        }

        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return 0;
            return int.Parse(userIdClaim.Value);
        }

        [HttpPost("convert")]
        public IActionResult Convert([FromBody] ConversionRequestDTO request)
        {
            try
            {
                Unit fromUnit = Unit.GetUnitByName(request.FromUnit);
                Unit toUnit = Unit.GetUnitByName(request.ToUnit);

                if (fromUnit == null || toUnit == null)
                    return BadRequest(new { message = "Invalid unit specified." });

                var result = _business.Convert(request.Value, fromUnit, toUnit, GetCurrentUserId());
                
                return Ok(new 
                { 
                    OriginalValue = request.Value, 
                    OriginalUnit = request.FromUnit, 
                    ConvertedValue = Math.Round(result.Value, 2), 
                    ConvertedUnit = request.ToUnit 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("compare")]
        public IActionResult Compare([FromBody] ComparisonRequestDTO request)
        {
            if (request == null) return BadRequest(new { message = "Request body is null." });

            try
            {
                Unit unit1 = Unit.GetUnitByName(request.Unit1);
                Unit unit2 = Unit.GetUnitByName(request.Unit2);

                if (unit1 == null || unit2 == null)
                    return BadRequest(new { message = "Unit not found." });

                if (unit1.Type != unit2.Type)
                    return BadRequest(new { message = "Category mismatch." });

                bool isEqual = _business.Compare(request.Value1, unit1, request.Value2, unit2, GetCurrentUserId());
                return Ok(new { IsEqual = isEqual });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("operation")]
        public IActionResult PerformOperation([FromBody] OperationRequestDTO request)
        {
            if (request == null) return BadRequest(new { message = "Request body is null." });

            try
            {
                Unit unit1 = Unit.GetUnitByName(request.Unit1);
                Unit? unit2 = null;
                string op = request.Operation?.ToLower() ?? "";

                if (op == "add" || op == "sub")
                {
                    unit2 = Unit.GetUnitByName(request.Unit2);
                    if (unit2 == null) return BadRequest(new { message = "Second unit is required." });
                }

                if (unit1 == null) return BadRequest(new { message = "First unit is invalid." });

                var result = _business.PerformOperation(request.Value1, unit1, request.Value2, unit2, op, GetCurrentUserId());
                return Ok(new 
                { 
                    Value = Math.Round(result.Value, 2), 
                    Unit = result.Unit.Name 
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("history")]
        public IActionResult DeleteHistory()
        {
            try
            {
                _business.DeleteHistory(GetCurrentUserId());
                return Ok(new { message = "History deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("history")]
        public IActionResult GetHistory()
        {
            try
            {
                var history = _business.GetHistory(GetCurrentUserId());
                return Ok(history);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}