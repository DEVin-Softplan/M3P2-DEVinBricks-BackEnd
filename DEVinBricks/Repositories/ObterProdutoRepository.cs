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

        public IEnumerable<Produto> ObterListaProduto(string? nome, int pagina, int tamanhoPagina)
        {
            var produtos = _context.Produtos as IQueryable<Produto>;

            if(!String.IsNullOrEmpty(nome))
                produtos = produtos.Where(x => x.Nome.Contains(nome));

            if(pagina > 0)
            {
                produtos = produtos.Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina);
            }

            return produtos;
        }
    }
}
