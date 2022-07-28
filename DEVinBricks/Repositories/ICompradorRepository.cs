using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface ICompradorRepository
    {
        Task<int> CadastrarComprador(CompradorPostDTO comprador, int authUserId);
        IEnumerable<Comprador> ListarGetComprador(CompradorGetDTO comprador);
        Comprador ObterPeloId(int id);
        Comprador EditarComprador(CompradorPatchDTO dto, int authUserId, int id);
        bool VerificaSeExisteCPFComprador(string cpf);
        bool VerificaSeExisteEmailComprador(string email);
        bool VerificaSeTemConteudo(string texto);
    }
}