using ClassLibraryLabs.Lab1;
using ClassLibraryLabs.Lab2;
using ClassLibraryLabs.Lab3;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LabsController : ControllerBase
    {
        [HttpGet("first")]
        public IActionResult First()
        {
            return Ok("First lab API endpoint. Provide input text via POST.");
        }

        [HttpPost("first")]
        public IActionResult First([FromBody] string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
            {
                return BadRequest("Input text cannot be null or empty.");
            }

            Lab1.Execute(inputText, out string outputResult);
            
            // var result = FirstLab.Execute(inputText);
            
            return Ok(new { OutputResult = outputResult });
        }

        [HttpGet("second")]
        public IActionResult Second()
        {
            return Ok("Second lab API endpoint. Provide input text via POST.");
        }

        [HttpPost("second")]
        public IActionResult Second([FromBody] string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
            {
                return BadRequest("Input text cannot be null or empty.");
            }

            // var result = SecondLab.Execute(inputText);
            Lab2.Execute(inputText, out string outputResult);
            
            return Ok(new { OutputResult = outputResult });
        }

        [HttpGet("third")]
        public IActionResult Third()
        {
            return Ok("Third lab API endpoint. Provide input text via POST.");
        }

        [HttpPost("third")]
        public IActionResult Third([FromBody] string inputText)
        {
            if (string.IsNullOrEmpty(inputText))
            {
                return BadRequest("Input text cannot be null or empty.");
            }

            Lab3.Execute(inputText, out string outputResult);
            // var result = ThirdLab.Execute(inputText);
            return Ok(new { OutputResult = outputResult });
        }
    }
}
