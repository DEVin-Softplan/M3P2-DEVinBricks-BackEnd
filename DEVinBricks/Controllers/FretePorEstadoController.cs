using Microsoft.AspNetCore.Mvc;
using DEVinBricks.Services.Interfaces;
using DEVinBricks.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

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
        /// Adiciona um valor do Frete por Estado
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>Valor do Frete por Estado criado</returns>
        /// <response code="201">Valor do Frete por Estado criado com sucesso</response>
        /// <response code="400">Já existe um cadastro desse estado</response>
        [HttpPost]
        [Route("novo")]
        [Authorize(Policy = "admin")]
        public IActionResult Adicionar([FromBody] ValorFretePorEstadoPostDTO dto)
        {
            var IdUsuarioAlteracao = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (_service.VerificarSeExisteCadastroDoEstado(dto.EstadoId))
            {
                return BadRequest("Já existe um cadastro desse estado. Tente editar o cadastro existente.");
            } 
            _service.Adicionar(dto, IdUsuarioAlteracao);
            return Created("Sucesso", dto);
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
        [Authorize(Policy = "admin")]
        [Route("editar/{id}")]
        public IActionResult Editar([FromBody] ValorFretePorEstadoDTO dto, int id)
        {
            var IdUsuarioAlteracao = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (dto.Id != id)
                return BadRequest("Dados inconsistentes");

            // verificar se o ID existe

            if (_service.VerificarSeExiste(id))
                return NotFound("Id não encontrado");


            // sucesso editado 201

           var model = _service.Atualizar(dto, IdUsuarioAlteracao);

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
        public IActionResult Consultar(string? nome, int page = 1, int size = 10)
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
