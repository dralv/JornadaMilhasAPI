using JornadaMilhasAPI.Models;
using JornadaMilhasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

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
        /// <summary>
        /// EndPoint para cadastra um novo depoimento
        /// </summary>
        /// <param name="depoimento"></param>
        /// <returns></returns>
        [HttpPost("cadastrar-depoimento")]
        public async Task<IActionResult> CadastrarDepoimento([FromBody]Depoimento depoimento)
        {
            await _service.CriarDepoimento(depoimento);
            return CreatedAtAction(nameof(ObterDepoimento), new { Id = depoimento.Id }, depoimento);
        }

        /// <summary>
        /// EndPoint para obter um depoimento
        /// </summary>
        /// <param name="id">Id do depoimento</param>
        /// <returns></returns>
        [HttpGet("obter-depoimento/{id}")]
        public async Task<IActionResult> ObterDepoimento(int id)
        {
            var resultado = await _service.ObterDepoimento(id);
            return Ok(resultado);
        }

        [HttpGet("obter-lista-depoimentos")]
        public async Task<IActionResult> ObterListaDepoimentos(int qtdItens)
        {
            var resultado = await _service.ObterDepoimentos(qtdItens);
            return Ok(resultado);
        }
    }
}
