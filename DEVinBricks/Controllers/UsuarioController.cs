using DEVinBricks.Controllers.Validacoes;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DEVinBricks.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using DEVinBricks.DTO;
using System.Security.Claims;

namespace DEVinBricks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase 
    {

        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;


        public UsuarioController(IUsuarioRepository usuarioRepository, IUsuarioService usuarioService)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
        }


        /// <summary>
        /// Busca usuário pelo Id
        /// </summary>
        /// <param name="id">Filtra pelo Id do usuário.</param>
        /// <returns>Dados do usuário</returns>
        /// <response code="200">Usuário encontrado.</response>
        /// <response code="401">Seu usuário não está autenticado no sistema.</response>
        /// <response code="403">Seu usário não tem permissão para acessar essa informação.</response>
        /// <response code="404">Usuário não encontrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = "admin")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObterUsuarioPorId(int id)
        {
            var usuario = _usuarioRepository.ObterUsuarioPorId(id);
            if (usuario == null) return NotFound("Usuario não encontrado");
            return Ok(usuario);
        }


        /// <summary>
        /// Obtem a lista de usuários do sistema
        /// </summary>
        /// <returns>Lista de usuários</returns>
        /// <response code="200">Usuários encontrados.</response>
        /// <response code="401">Seu usuário não está autenticado no sistema.</response>
        /// <response code="403">Seu usário não tem permissão para acessar essa informação.</response>
        /// <response code="404">Nenhum usuário encontrado.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = "admin")]
        public IActionResult ObterListaUsuarios(string nome = "sem nome", string login = "sem login", int tamanho = 0, int pagina = 1)
        {
            var usuarios = _usuarioRepository.listarUsuarios(nome, login, tamanho, pagina);
            return Ok(usuarios);
        }


        /// <summary>
        /// Cadastra novo usuário no sistema
        /// </summary>
        /// <returns>Inclusão de usuário no sistema</returns>
        /// <response code="201">Usuário cadastrado.</response>
        /// <response code="401">Seu usuário não está autenticado no sistema.</response>
        /// <response code="403">Seu usário não tem permissão para acessar essa informação.</response>
        /// <response code="422">Já existe um usuário cadastrado com esse mesmo email.</response>
        /// <response code="400">Email ou Login já existente</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarUsuarioDTO dadosUsuario)
        {
            try
            {
                if (await _usuarioService.VerificarSeEmailExiste(dadosUsuario.Email)) return BadRequest("O email informado já existe.");

                if (await _usuarioService.VerificarSeLoginExiste(dadosUsuario.Login)) return BadRequest("O login informado já existe.");

                int IdUsuarioInclusao = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                var usuario = await _usuarioService.CriarUsuario(dadosUsuario, IdUsuarioInclusao);

                var validador = new ValidarUsuario();
                var valido = validador.Validate(usuario);

                if (valido.IsValid)
                {
                    var resultado = await _usuarioService.CadastrarUsuario(usuario);
                    return Created("Create", resultado);
                }
                else
                {
                    return UnprocessableEntity(new { message = valido.ToString() });
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException); ;
            }
        }

        /// <summary>
        /// Altera dados do usuário
        /// </summary>
        /// <returns>Alteração de dados do usuário</returns>
        /// <response code="200">Usuário alterado.</response>
        /// <response code="401">Seu usuário não está autenticado no sistema.</response>
        /// <response code="403">Seu usário não tem permissão para acessar essa informação.</response>
        /// <response code="422">Dados Inválidos.</response>
        /// <response code="404">Nenhum usuário encontrado.</response>
        /// <response code="400">Email ou Login já existente</response>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> EditarDados([FromBody] EditarUsuarioDTO usuarioAlterado)
        {
            try
            {
                if(await _usuarioService.VerificarSeEmailExiste(usuarioAlterado.Email)) return BadRequest("O email informado já existe.");

                if (await _usuarioService.VerificarSeLoginExiste(usuarioAlterado.Login)) return BadRequest("O login informado já existe.");

                var usuario = await _usuarioService.VerificarDadosAlterados(usuarioAlterado);
                if (usuario == null) return NotFound("Usuario não encontrado");

                var validador = new ValidarUsuario();
                var valido = validador.Validate(usuario);

                if (valido.IsValid)
                {
                    int IdUsuarioAlteracao = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                    await _usuarioService.AlterarDadosUsuario(usuario, IdUsuarioAlteracao);

                    return Ok("Usuario alterado com sucesso!");
                }
                else
                {
                    return UnprocessableEntity(valido.ToString());
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException); ;
            }
        }
    }
}
