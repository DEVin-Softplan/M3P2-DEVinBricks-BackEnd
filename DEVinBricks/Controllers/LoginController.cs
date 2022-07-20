using DEVinBricks.DTO;
using DEVinBricks.Models;
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

        public LoginController(DEVinBricksContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Realiza login por login e senha
        /// </summary>
        /// <returns>Token de Autenticação</returns>
        /// <response code="200">Login efetuado com sucesso.</response>
        /// <response code="404">Login e/ou senha incorreto(s).</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public IActionResult Login([FromBody] LoginDTO dto)
        {
            try
            {
                var usuario = _context.Usuarios.First(x => x.Login.ToLower() == dto.Login.ToLower() && x.Senha.ToLower() == dto.Senha.ToLower());

                if (usuario == null) return NotFound("Login e/ou senha incorreto(s)");

                var token = TokenService.GerarToken(usuario);

                return Ok($"Bem-vindo(a) {usuario.Nome} ao sistema da DEVinBricks!. Segue seu token: \n\n" + token);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
