using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface IObterVendaProdutoRepository
    {
        public VendaProduto ObterVendaProdutoPorIdVenda(int IdVenda);
    }
}
