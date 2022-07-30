using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DEVinBricksContext _context;
        public VendaRepository(DEVinBricksContext context)
        {
            _context = context;
        }

        //public Venda ObterVendaPorIdVenda(int IdVenda)
        //{
        //    var response = _context.Vendas.Find(IdVenda);
        //    return response;
        //}
        
        public VendaProduto ObterVendaPorIdVenda(int IdVenda)
        {            
            return _context.VendasProdutos.Find(IdVenda); 
        }

        public Produto ObterProdutoPeloId(int id)
        {
            return _context.Produtos.FirstOrDefault(x => x.Id == id);
        }
    }
}