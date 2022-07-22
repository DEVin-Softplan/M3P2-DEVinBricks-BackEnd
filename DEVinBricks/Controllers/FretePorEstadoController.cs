
using Microsoft.AspNetCore.Mvc;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Services.Interfaces;
using DEVinBricks.DTO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

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
    }
}
