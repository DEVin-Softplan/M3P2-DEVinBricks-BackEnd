using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories {
    public interface IVendaRepository {
        public Venda CadastrarNovaVenda(int vendedorId, int compradorId, int produtoId, int produtoQuantidade);
        public IEnumerable<Venda> ObterListaDeVendas(int usuarioId, string? compradorNome, string? compradorCpf, int? paginaNumero, int? paginaTamanho);
        public Venda ObterDadosDaVenda(int vendaId);
        public Venda CancelamentoDeVenda(int vendaId);
    }
}