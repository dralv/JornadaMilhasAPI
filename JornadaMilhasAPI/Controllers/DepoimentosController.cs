using JornadaMilhasAPI.Dtos;
using JornadaMilhasAPI.Models;
using JornadaMilhasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace JornadaMilhasAPI.Controllers
{
    /// <summary>
    /// Classe Controladora
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DepoimentosController : ControllerBase
    {
        private readonly IDepoimentoService _service;
        /// <summary>
        /// Construtor do controller
        /// </summary>
        /// <param name="service"></param>
        public DepoimentosController(IDepoimentoService service)
        {
            _service = service;
        }
        /// <summary>
        /// EndPoint para cadastra um novo depoimento
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("cadastrar-depoimento")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CadastrarDepoimento([FromBody]DepoimentoDto dto)
        {
            var resultado = await _service.CriarDepoimento(dto);
            if (resultado != 0) return Created(nameof(ObterDepoimento),dto);
            return BadRequest();
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
            if(resultado !=null) return Ok(resultado);
            return NotFound();

        }
        /// <summary>
        /// EndPoint para atualizar um depoimento
        /// </summary>
        /// <param name="dto">Campos a serem atualizados</param>
        /// <param name="id">Id do campo para atualizar</param>
        /// <returns></returns>
        [HttpPut("atualizar-depoimento/{id}")]
        public async Task<IActionResult> AtualizarDepoimento([FromBody]DepoimentoDto dto,int id)
        {
            var resultado = await _service.AtualizarDepoimento(dto,id);
            if (resultado != 0) return NoContent();
            return BadRequest();
        }
       

        /// <summary>
        /// Endpoint para deletar um depoimento
        /// </summary>
        /// <param name="id">Id do depoimento a ser excluído</param>
        /// <returns></returns>
        [HttpDelete("deletar-depoimento/{id}")]
        public async Task<IActionResult> DeletarDepoimento(int id)
        {
            var resultado = await _service.DeletarDepoimento(id);
            if(resultado!=0) return NoContent();
            return BadRequest();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="qtdItens">Quantidade de itens a ser retornado</param>
        /// <returns></returns>

        [HttpGet("obter-lista-depoimentos/{qtdItens}")]
        public async Task<IActionResult> ObterListaDepoimentos(int qtdItens)
        {
            var resultado = await _service.ObterDepoimentos(qtdItens);
            return Ok(resultado);
        }
    }
}
