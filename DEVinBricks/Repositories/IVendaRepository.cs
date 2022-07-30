using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface IVendaRepository
    {
        public VendaProduto ObterVendaPorIdVenda(int IdVenda);       
    }
}
