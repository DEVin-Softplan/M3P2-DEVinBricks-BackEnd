using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Services.Interfaces
{
    public interface IObterProdutoService
    {
        public ObterProdutoPorIdDTO ObterProdutoPorId(int id);
    }
}
