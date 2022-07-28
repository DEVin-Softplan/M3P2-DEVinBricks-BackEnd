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
        [HttpGet("api/Produto/Cadastro")]
        public async Task<ActionResult> CriarCadastroDeProduto([FromBody] CadastroDeProdutoDTO produtoDTO)
        {
            if (_service.VerificaSeExisteProduto == null)
            {
                return NotFound();
            }
            return await _service.CadastroDeProdutoDTO.ToListAsync();
        }

        /// <summary>
        /// Cadastre um Produto
        /// </summary>
        /// <returns>Produto cadastrado com sucesso!</returns>
        /// <response code="200">Cadastro encontrado com sucesso.</response>
        /// <response code="400">Já existe Produto cadastrado.</response>
        [HttpGet("api/Produto/Cadastro/{id}")]
        public async Task<ActionResult<CadastroDeProdutoDTO>> GetCadastroDeProdutoDTO(int id)
        {
            if (_service.CadastroDeProdutoDTO == null)
            {
                return NotFound();
            }
            var cadastroDeProdutoDTO = await _service.CadastroDeProdutoDTO.FindAsync(id);

            if (cadastroDeProdutoDTO == null)
            {
                return NotFound();
            }

            return cadastroDeProdutoDTO;
        }


        // POST: api/CadastroDeProdutoDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("api/Produto/Publicar/Cadastro")]
        public async Task<ActionResult<CadastroDeProdutoDTO>> PostCadastroDeProdutoDTO(CadastroDeProdutoDTO cadastroDeProdutoDTO)
        {
            if (_service.CadastroDeProdutoDTO == null)
            {
                return Problem("Entity set 'DEVinBricksContext.CadastroDeProdutoDTO'  is null.");
            }
            _service.CadastroDeProdutoDTO.Add(cadastroDeProdutoDTO);
            await _service.SaveChangesAsync();

            return CreatedAtAction("GetCadastroDeProdutoDTO", new { id = cadastroDeProdutoDTO.Id }, cadastroDeProdutoDTO);
        }

        // DELETE: api/CadastroDeProdutoDTOes/5
        [HttpDelete("api/Produto/Excluir/{id}")]
        public async Task<IActionResult> DeleteCadastroDeProdutoDTO(int id)
        {
            if (_service.CadastroDeProdutoDTO == null)
            {
                return NotFound();
            }
            var cadastroDeProdutoDTO = await _service.CadastroDeProdutoDTO.FindAsync(id);
            if (cadastroDeProdutoDTO == null)
            {
                return NotFound();
            }

            _service.CadastroDeProdutoDTO.Remove(cadastroDeProdutoDTO);
            await _service.SaveChangesAsync();

            return NoContent();
        }

        private bool CadastroDeProdutoDTOExists(int id)
        {
            return (_service.CadastroDeProdutoDTO?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

