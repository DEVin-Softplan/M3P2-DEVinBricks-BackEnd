using DEVinBricks.Repositories.Models;
using DEVinBricks.Repositories;

namespace DEVinBricks.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<int> CadastrarUsuario(Usuario usuario)
        {
            return await _usuarioRepository.CadastrarUsuario(usuario);
        }

        public async Task<bool> VerificaSeEmailExiste(string email)
        {
            return await _usuarioRepository.VerificaSeEmailExiste(email);
        }
    }
}
