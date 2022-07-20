using DEVinBricks.DTO;
using DEVinBricks.Models;
using DEVinBricks.Repositories;
using DEVinBricks.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEVinBricks.Controllers
{
    [Route("/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DEVinBricksContext _context;

        private IUsuarioRepository _service;

        public LoginController(IUsuarioRepository context)
        {
            _service = context;
        }

        /// <summary>
        /// Realiza login por login e senha
        /// </summary>
        /// <returns>Token de Autenticação</returns>
        /// <response code="200">Login efetuado com sucesso.</response>
        /// <response code="404">Login e/ou senha incorreto(s).</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            var usuario = _service.ObterPorLoginESenha(dto.Login, dto.Senha);

            if (usuario == null) return NotFound("Login e/ou senha incorreto(s)");

            var token = TokenService.GerarToken(usuario);

            return Ok($"Bem-vindo(a) {usuario.Nome} ao sistema da DEVinBricks!. Segue seu token: \n\n" + token);
        }
    }
}
