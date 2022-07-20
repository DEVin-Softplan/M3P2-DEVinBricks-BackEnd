using DEVinBricks.DTO;
using DEVinBricks.Models;

namespace DEVinBricks.Repositories
{
    public interface IUsuarioRepository
    {
        public List<Usuario> listarUsuarios();

        public Usuario ObterPorLoginESenha(string login, string senha);

    }

}
