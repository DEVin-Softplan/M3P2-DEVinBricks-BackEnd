using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Services.Interfaces
{
    public interface IVendaService
    {
        Task<int> CadastrarVenda(int idProduto, int quantidadeProduto, int idComprador, int idVendedor);        
    }
}
