using DEVinBricks.Controllers.Validacoes;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Repositories;
using DEVinBricks.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("ObterListaUsuarios/{nome?}/{login?}/{tamanho:int?}/{pagina:int?}")]
        public IActionResult ObterListaUsuarios(string nome = "sem nome", string login = "sem login", int tamanho = 0, int pagina = 1)
        {
            var usuarios = _usuarioRepository.listarUsuarios(nome, login, tamanho, pagina);
            return Ok(usuarios);
        }

        [HttpPost("/usuario")]
        public async Task<IActionResult> Cadastrar([FromBody] Usuario usuario)
        {
            try
            {
                var validador = new ValidarUsuario();
                var valido = validador.Validate(usuario);

                if (valido.IsValid)
                {
                    if (await _usuarioService.VerificaSeEmailExiste(usuario.Email))
                    {
                        return UnprocessableEntity(new { message = "Já existe um usuário cadastrado com esse mesmo email" });
                    }
                    var resultado = await _usuarioService.CadastrarUsuario(usuario);
                    return Ok(new { message = "Usuario cadastrado com sucesso!", id = resultado });
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
    }
}
