using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface IUsuarioRepository
    {
        public List<Usuario> listarUsuarios(string nome, string login, int tamanho, int pagina);
        public Usuario ObterPorLoginESenha(string login, string senha);
        Task<Usuario> CadastrarUsuario(Usuario usuario);
        Task<bool> VerificarSeEmailExiste(string email);
        Task<bool> VerificarSeLoginExiste(string login);
        public Usuario ObterUsuarioPorId(int id); 
        Task<Usuario> AlterarDados(Usuario usuario);
    }

}
