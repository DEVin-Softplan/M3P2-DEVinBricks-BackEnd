using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Services.Interfaces
{
    public interface IObterProdutoService
    {
        public Produto ObterProdutoPorId(int id);
    }
}
