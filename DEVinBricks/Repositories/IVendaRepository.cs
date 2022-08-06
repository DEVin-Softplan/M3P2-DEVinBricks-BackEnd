using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface IVendaRepository
    {        
        Task<int> CadastrarVenda(VendaPostDTO venda, int usuarioInclusaoId);
        IEnumerable<VendaModel> ListarGetVenda(VendaGetDTO venda);        
        public IEnumerable<VendaPostDTO> ConsultarVendaPorComprador(string? nome, string? cpf, int page, int size);
        public VendaModel ObterPeloId(int id);

        public VendaProdutoModel ObterVendaProdutoPorIdVenda(int idVenda);
        //public IEnumerable<VendaProdutoGetDTO> ConsultarVendaProdutoPorIdVenda(int idVenda);
    }
}