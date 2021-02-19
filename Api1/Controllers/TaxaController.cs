using System.Threading.Tasks;
using Api1.Routes;
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
        [Route(ApiRoutes.Taxa.Get.TaxaJuros)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<decimal>> GetTaxaJuros()
        {
            return await Task.Run(() => 0.01M);
        }
    }
}