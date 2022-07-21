using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface IUsuarioRepository
    {
        public List<Usuario> listarUsuarios(string nome, string login, int tamanho, int pagina);
        public Usuario ObterPorLoginESenha(string login, string senha);
        Task<int> CadastrarUsuario(Usuario usuario);
        Task<bool> VerificaSeEmailExiste(string email);

        public Usuario ObterUsuarioPorId(int id); 

    }

}
