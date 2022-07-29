using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface IProdutoRepository
    {
        public Produto ObterProdutoPorId(int id);
        public IEnumerable <Produto> ObterListaProduto(string? nome, int pagina, int tamanhoPagina );
        public Produto EditarProduto( Produto produto );
        public bool VerificaNome(string nome);
    }
}
