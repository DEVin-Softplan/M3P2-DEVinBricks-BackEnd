using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface ICompradorRepository
    {
        Task<int> CadastrarComprador(CompradorPostDTO comprador);
        IEnumerable<Comprador> ListarGetComprador(CompradorGetDTO comprador);
        bool VerificaSeExisteCPFComprador(string cpf);
        bool VerificaSeExisteEmailComprador(string email);
        public Comprador ObterPeloId(int id);

    }
}