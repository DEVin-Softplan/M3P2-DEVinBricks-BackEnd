using DEVinBricks.DTO;

namespace DEVinBricks.Repositories
{
    public interface ICompradorRepository
    {
        Task<int> CadastrarComprador(CompradorDTO comprador);
    }
}