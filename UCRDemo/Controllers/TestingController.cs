using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UCRDemo.Services;

namespace UCRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestingController : ControllerBase
    {
        private readonly IUCRService service;

        public TestingController(IUCRService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await service.Authication(UCRService.AuthicationType.UCRVerifiy));
        }
    }
}
