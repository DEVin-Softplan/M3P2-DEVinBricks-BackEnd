using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Repositories;

namespace DEVinBricks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroDeProdutoDTOesController : ControllerBase
    {
        private ICadastroDeProdutoRepository _service;

        public CadastroDeProdutoDTOesController(ICadastroDeProdutoRepository context)
        {
            _service = context;
        }

        /// <summary>
        /// Cadastre um Produto
        /// </summary>
        /// <returns>Produto cadastrado com sucesso!</returns>
        /// <response code="200">Cadastro realizado com sucesso.</response>
        /// <response code="400">Já existe Produto cadastrado.</response>
        [HttpPost("api/Produto/CadastraProduto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CriarCadastroDeProduto([FromBody] CadastroDeProdutoDTO produtoDTO)
        {
            if (_service.VerificaSeExisteProduto(produtoDTO.Nome))
                return BadRequest($"O Produto '{produtoDTO.Nome}' já existente");
            var cadastroInserido = await _service.CadastrarProduto(produtoDTO);
            return Ok(new
            {
                message = "Prosuto cadastrado com sucesso!",
                Id = cadastroInserido,
                NovoProduto = produtoDTO
            });
        }
    }
}