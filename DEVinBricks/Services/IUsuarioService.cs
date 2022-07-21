using DEVinBricks.Models;

namespace DEVinBricks.Services
{
    public interface IUsuarioService
    {
        Task<int> CadastrarUsuario(Usuario usuario);
        Task<bool> VerificaSeEmailExiste(string email);
    }
}
