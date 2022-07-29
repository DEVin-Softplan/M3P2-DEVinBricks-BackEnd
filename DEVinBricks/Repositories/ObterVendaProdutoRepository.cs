using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public class ObterVendaProdutoRepository : IObterVendaProdutoRepository
    {
        private readonly DEVinBricksContext _context;
        public ObterVendaProdutoRepository(DEVinBricksContext context)
        {
            _context = context;
        }
        public VendaProduto ObterVendaProdutoPorIdVenda(int IdVenda)
        {
            var response = _context.VendasProdutos.Find(IdVenda);
            return response;

        }
    }
}