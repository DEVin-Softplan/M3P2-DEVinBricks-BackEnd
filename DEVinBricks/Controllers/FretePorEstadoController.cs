
using Microsoft.AspNetCore.Mvc;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Services.Interfaces;
using DEVinBricks.DTO;

namespace DEVinBricks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FretePorEstadoController : ControllerBase
    {
        private readonly IValorFretePorEstadoService _service;
        public FretePorEstadoController(IValorFretePorEstadoService service)
        {
            _service = service;
        }


        /// <summary>
        /// Edita o valor do Frete por Estado
        /// </summary>
        /// <returns>Token de Autenticação</returns>
        /// <response code="201">Login efetuado com sucesso.</response>
        /// <response code="404">Login e/ou senha incorreto(s).</response>
       
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
       [Route("editar/{id}")]
       public IActionResult Editar([FromBody] ValorFretePorEstadoDTO dto, int id)
        {
            if (dto.Id != id)
                return BadRequest("Dados inconsistentes");

            // verificar se o ID existe
           
            if (_service.VerificarSeExiste(id))
                return NotFound("Id não encontrado");
            
            
            // sucesso editado 201
           var model = _service.Atualizar(dto);
            
                
            return Ok(model);
        }
    }
}
