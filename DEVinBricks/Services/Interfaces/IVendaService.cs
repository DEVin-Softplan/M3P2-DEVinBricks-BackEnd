using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Services.Interfaces {
    public interface IVendaService {
        public ObterVendaProdutoPorIdVendaDTO ObterVendaProdutoPorIdVenda(int idVenda);
        public string CriarVenda(CriarVendaDTO venda, int usuarioInclusao);
        public IEnumerable<VendaPostDTO> ConsultarVendaPorComprador(string? nome, string? cpf, int page, int size);
    }
}