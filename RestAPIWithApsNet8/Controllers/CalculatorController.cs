using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;

namespace RestAPIWithApsNet8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }
        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, //out number);
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo,
            out number);
            return isNumber;

        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        [HttpGet("sum/{firstNumber}/{secundNumber}")]
        public IActionResult Sum(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secundNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Ivalid input");
        }

        [HttpGet("sub/{firstNumber}/{secundNumber}")]
        public IActionResult Sub(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secundNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Ivalid input");
        }

        [HttpGet("mult/{firstNumber}/{secundNumber}")]
        public IActionResult Mult(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secundNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Ivalid input");
        }
        [HttpGet("div/{firstNumber}/{secundNumber}")]
        public IActionResult Div(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secundNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Ivalid input");
        }
        [HttpGet("media/{firstNumber}/{secundNumber}")]
        public IActionResult Media(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secundNumber) / 2;
                return Ok(sum.ToString());
            }
            return BadRequest("Ivalid input");
        }
        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult Sqrt(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var sum = Math.Sqrt((double)ConvertToDecimal(firstNumber));
                return Ok(sum.ToString("f2", CultureInfo.InvariantCulture));
            }
            return BadRequest("Ivalid input");
        }
    }
}
