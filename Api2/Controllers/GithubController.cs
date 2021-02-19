using System.Threading.Tasks;
using Api2.Routes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api2.Controllers
{
    [ApiController]
    [Route("controller")]
    public class GithubController : ControllerBase
    {
        private readonly IConfiguration _config;
        
        public GithubController(IConfiguration config)
        {
            _config = config;
        }
        
        [HttpGet]
        [Route(ApiRoutes.Github.Get.ShowTheCode)]
        public async Task<string> GetUrl()
        {
            return await Task.Run(() => _config.GetValue<string>("urls:github"));
        }
    }
}