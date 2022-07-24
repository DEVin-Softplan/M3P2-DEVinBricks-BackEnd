using DEVinBricks.DTO;

namespace DEVinBricks.Repositories
{
    public interface ICompradorRepository
    {
        Task<int> CadastrarComprador(CompradorDTO comprador);
        bool VerificaSeExisteCPFComprador(string cpf);
        bool VerificaSeExisteEmailComprador(string email);
    }
}