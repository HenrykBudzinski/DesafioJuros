using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FinanceiroCore.Comum.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Api2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceiroController : ControllerBase
    {
        // private readonly ILogger _logger;
        private readonly IConfiguration _config;
        private readonly ICalculadoraFinanceira _calc;
        

        public FinanceiroController(IConfiguration config, ICalculadoraFinanceira calc)
        {
            // _logger = logger;
            _config = config;
            _calc = calc;
        }

        [HttpGet]
        [Route("/calculaJuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<decimal>> CalculaJuros(
            [FromQuery]decimal valorinicial, 
            [FromQuery]int meses)
        {
            try
            {
                var valorTotal = await _calc.CalcularJurosCompostoAsync(valorinicial, meses);
                return valorTotal;
            }
            catch (ArgumentException argEx)
            {
                var result = new ObjectResult(new
                {
                    error = argEx.Message,
                    param = argEx.ParamName,
                    dateTime = DateTime.Now
                });
                result.StatusCode = StatusCodes.Status400BadRequest;
                return result;
            }
            catch (HttpRequestException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable);
            }
        }
    }
}