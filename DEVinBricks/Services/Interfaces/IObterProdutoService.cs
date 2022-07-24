using DEVinBricks.DTO;

namespace DEVinBricks.Services.Interfaces
{
    public interface IObterProdutoService
    {
        public ObterProdutoPorIdDTO ObterProdutoPorId(int id);
    }
}