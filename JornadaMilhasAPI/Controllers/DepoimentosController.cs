using JornadaMilhasAPI.Models;
using JornadaMilhasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JornadaMilhasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepoimentosController : ControllerBase
    {
        private readonly IDepoimentoService _service;

        public DepoimentosController(IDepoimentoService service)
        {
            _service = service;
        }

        [HttpPost("cadastrar-depoimento")]
        public async Task<IActionResult> CadastrarDepoimento([FromBody]Depoimento depoimento)
        {
            await _service.CriarDepoimento(depoimento);
            return Ok();
        }
    }
}
