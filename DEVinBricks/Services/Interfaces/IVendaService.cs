using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Services.Interfaces
{
    public interface IVendaService
    {   
        //public ObterVendaProdutoPorIdVendaDTO ObterVendaProdutoPorIdVenda(int idVenda);

        public IEnumerable<VendaModel> ConsultarVendaPorComprador(string? nome, string? cpf, int page, int size);
    }
}
