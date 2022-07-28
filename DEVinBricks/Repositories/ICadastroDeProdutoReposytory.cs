using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;
using static DEVinBricks.DTO.CadastroDeProdutoDTO;

namespace DEVinBricks.Repositories
{
    public interface ICadastroDeProdutoRepository
    {
        public Task<int> CadastrarProduto(CadastroDeProdutoDTO produtoDTO);
        IEnumerable<ProdutoModel> ListarProdutos(CadastroGetDoDTO produtoDTO);
        bool VerificaSeExisteProduto(string nome);
        public ProdutoModel ObterPeloIdCadastro(int id);
    }
}
