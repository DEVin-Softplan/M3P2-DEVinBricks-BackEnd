using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface IVendaRepository
    {
        public VendaProduto ObterVendaPorIdVenda(int IdVenda);
        Task<int> CadastrarVenda(VendaPostDTO venda, int usuarioInclusaoId);
        IEnumerable<Venda> ListarGetVenda(VendaGetDTO venda);    
        public Venda ObterPeloId(int id);

    }
}