using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinanceiroController : ControllerBase
    {
        // private readonly ILogger _logger;
        //
        // public FinanceiroController(ILogger<FinanceiroController> logger)
        // {
        //     _logger = logger;
        // }
        
        [HttpGet]
        [Route("/calculaJuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable)]
        public async Task<ActionResult<decimal>> CalculaJuros(
            [FromQuery]decimal valorinicial, 
            [FromQuery]int meses)
        {
            if (valorinicial < 0)
            {
                return BadRequest();
            }
            
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://localhost:8001/taxaJuros");
                if (!result.IsSuccessStatusCode)
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "O serviço que define os juros está fora do ar");
                }

                double juros;
                var resultContent = await result.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(resultContent) || !double.TryParse(resultContent, out juros))
                {
                    return StatusCode(500);
                }
                
                var jurosTotal = Math.Pow(1 + juros, meses);
                var valorTotal = valorinicial * (decimal) jurosTotal;
                return Math.Truncate(100m * valorTotal) / 100m;
            }
        }
    }
}