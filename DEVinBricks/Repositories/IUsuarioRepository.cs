using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface IUsuarioRepository
    {
        public List<Usuario> listarUsuarios();

        public Usuario ObterPorLoginESenha(string login, string senha);
        Task<int> CadastrarUsuario(Usuario usuario);
        Task<bool> VerificaSeEmailExiste(string email);

    }

}
