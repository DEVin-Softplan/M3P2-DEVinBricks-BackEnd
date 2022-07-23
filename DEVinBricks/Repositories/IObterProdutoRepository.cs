using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface IObterProdutoRepository
    {
        public Produto ObterProdutoPorId(int id);
    }
}
