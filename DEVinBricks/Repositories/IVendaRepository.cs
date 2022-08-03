using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface IVendaRepository
    {
        public VendaProdutoModel ObterVendaPorIdVenda(int IdVenda);
        Task<int> CadastrarVenda(VendaPostDTO venda, int usuarioInclusaoId);
        IEnumerable<VendaModel> ListarGetVenda(VendaGetDTO venda);    
        public VendaModel ObterPeloId(int id);

    }
}