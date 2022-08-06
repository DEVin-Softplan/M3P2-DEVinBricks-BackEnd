using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Services.Interfaces
{
    public interface IProdutoService
    {
        public ObterProdutoPorIdDTO ObterProdutoPorId(int id);
        public List<ObterListaProdutoDTO> ObterListaProduto(string nome, int pagina, int tamanhoPagina);
        public Produto EditarProduto(ObterProdutoPorIdDTO produto, int IdUsuarioAlteracao);
        public bool VerificaNome(string nome);
    }
}