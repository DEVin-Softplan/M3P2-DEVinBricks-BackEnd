using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public class ObterProdutoRepository : IObterProdutoRepository
    {
        private readonly DEVinBricksContext _context;
        public ObterProdutoRepository(DEVinBricksContext context)
        {
            _context = context;
        }
        public Produto ObterProdutoPorId(int id)
        {
            var response = _context.Produtos.Find(id);
            return response;

        }
    }
}
