using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaculatorController : ControllerBase
    {

        private readonly ILogger<CaculatorController> _logger;

        public CaculatorController(ILogger<CaculatorController> logger)
        {
            _logger = logger;
        }

        //Sum
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        //Subtraction
        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var subtraction = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                return Ok(subtraction.ToString());
            }
            return BadRequest("Invalid Input");
        }

        //Multiplication
        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                return Ok(multiplication.ToString());
            }
            return BadRequest("Invalid Input");
        }


        //Media
        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

                return Ok(mean.ToString());
            }
            return BadRequest("Invalid Input");
        }

        //Square
        [HttpGet("square/{firstNumber}")]
        public IActionResult Square(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var squareRoot = Math.Sqrt((double)(ConvertToDecimal(firstNumber)));

                return Ok(squareRoot.ToString());
            }
            return BadRequest("Invalid Input");
        }




        private bool IsNumeric(string strNumber)
        {
            double number;

            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);

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
    }
}