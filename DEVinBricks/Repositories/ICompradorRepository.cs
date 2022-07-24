using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface ICompradorRepository
    {
        Task<int> CadastrarComprador(CompradorPostDTO comprador);
        IEnumerable<Comprador> ListarComprador(CompradorGetDTO comprador);
        bool VerificaSeExisteCPFComprador(string cpf);
        bool VerificaSeExisteEmailComprador(string email);
    }
}