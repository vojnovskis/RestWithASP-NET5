using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers
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

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");

        }

            [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
            public IActionResult Subtraction(string firstNumber, string secondNumber)
            {
                if (IsNumeric(secondNumber) && IsNumeric(secondNumber))
                {
                    var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                    return Ok(subtraction.ToString());
                }
                return BadRequest("Invalid Input");

        }


        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
            public IActionResult Multiplication(string firstNumber, string secondNumber)
            {
                if (IsNumeric(secondNumber) && IsNumeric(secondNumber))
                {
                    var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                    return Ok(multiplication.ToString());
                }
                return BadRequest("Invalid Input");

            
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult division(string firstNumber, string secondNumber)
        {
            if (IsNumeric(secondNumber) && IsNumeric(secondNumber))
            {
                var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(division.ToString());
            }
            return BadRequest("Invalid Input");

        }
    private bool IsNumeric(string strNumber)
        {
            double number;
            bool IsNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return IsNumber;


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

    
    }
}