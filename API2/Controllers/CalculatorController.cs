using Domain.DTOs;
using Domain.Helpers;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet("calculajuros")]
        public async Task<IActionResult> CalculateInterest([FromQuery] CalculatorDTO calculatorDTO)
        {
            decimal result = await _calculatorService.GetTotalCompoundInterestGain(calculatorDTO.ValorInicial, calculatorDTO.Meses);
            return Ok(result);
        }

        [HttpGet("showmethecode")]
        public ActionResult<Uri> ShowMeTheCode()
        => new Uri("https://github.com/vitorlimadesenvolvedor/Calculator");
    }
}