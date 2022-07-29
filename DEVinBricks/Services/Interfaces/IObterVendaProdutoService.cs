using DEVinBricks.DTO;

namespace DEVinBricks.Services.Interfaces
{
    public interface IObterVendaProdutoService
    {
        public ObterVendaProdutoPorIdVendaDTO ObterVendaProdutoPorIdVenda(int idVenda);
    }
}