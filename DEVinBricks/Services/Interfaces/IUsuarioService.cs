using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<int> CadastrarUsuario(Usuario usuario);
        Task<bool> VerificarSeEmailExiste(string email);
        void EnviarEmailParaFila(Usuario usuario);
        Task<Usuario> VerificarDadosAlterados(EditarUsuarioDTO usuarioAlterado);
        bool verificaSeTemConteudo(string texto);
    }
}
