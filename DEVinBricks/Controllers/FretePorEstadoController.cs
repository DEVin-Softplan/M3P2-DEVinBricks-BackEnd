using Microsoft.AspNetCore.Mvc;
using DEVinBricks.Services.Interfaces;
using DEVinBricks.DTO;
using Microsoft.AspNetCore.Authorization;

namespace DEVinBricks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FretePorEstadoController : ControllerBase
    {
        private readonly IValorFretePorEstadoService _service;
        const int maxPageSize = 20;

        public FretePorEstadoController(IValorFretePorEstadoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Edita o valor do Frete por Estado
        /// </summary>
        /// <returns>Valor do Frete por Estado Atualizado</returns>
        /// <response code="200">Valor do Frete por Estado atualizado com sucesso</response>
        /// <response code="404">Id não encontrado no database</response>
        /// <response code="400">Dados Inconsistentes, verifique o Id</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        [Authorize]
        [Route("editar/{id}")]
        public IActionResult Editar([FromBody] ValorFretePorEstadoDTO dto, int id)
        {
            var teste = User.Identity.Name;
            if (dto.Id != id)
                return BadRequest("Dados inconsistentes");

            // verificar se o ID existe

            if (_service.VerificarSeExiste(id))
                return NotFound("Id não encontrado");


            // sucesso editado 201
            var model = _service.Atualizar(dto);


            return Ok(model);
        }

        /// <summary>
        /// Consulta lista de Valores de Frete por.
        /// </summary>
        /// <param name="nome">Filtra por nome do Estado.</param>
        /// <param name="page">Número da página.</param>
        /// <param name="size">Tamanho da página.</param>
        /// <returns>Valor do Frete por Estado.</returns>
        /// <response code="200">Valor do Frete por Estado consultado.</response>
        /// <response code="400">Requisição inválida.</response>
        /// <response code="401">Usuário não autorizado.</response>
        /// <response code="404">Valor do Frete por Estado não encontrado.</response>
        /// <response code="500">Ocorreu uma exceção durante a consulta.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Authorize(Policy = "admin")]
        public IActionResult Consulta(string? nome, int page = 1, int size = 10)
        {
            if (size > maxPageSize)
            {
                size = maxPageSize;
            }

            var resultado = _service.Consultar(nome, page, size);

            return Ok(resultado);
        }
    }
}
