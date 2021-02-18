using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaController : ControllerBase
    {
        // private readonly ILogger<TaxaController> _logger;
        //
        // public TaxaController(ILogger<TaxaController> logger)
        // {
        //     _logger = logger;
        // }
        
        [HttpGet]
        [Route("/taxaJuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<decimal>> Get()
        {
            return await Task.Run(() => 0.01M);
        }
    }
}