using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Services.Interfaces;

namespace DEVinBricks.Services {
    public class VendaService : IVendaService {
        private readonly IVendaRepository _repository;
        private readonly IProdutoRepository _produtoRepository;
        public VendaService(IVendaRepository repository, IProdutoRepository produto) {
            _repository = repository;
            _produtoRepository = produto;
        }
        public ObterVendaProdutoPorIdVendaDTO ObterVendaProdutoPorIdVenda(int idVenda)  {
            var venda = _repository.ObterVendaProdutoPorIdVenda(idVenda);
            var produto = _produtoRepository.ObterProdutoPorId(venda.IdProduto);

            var vendaProdutoDTO = new ObterVendaProdutoPorIdVendaDTO() {
                Id = venda.Id,
                IdVenda = venda.IdVenda,
                IdProduto = venda.IdProduto,
                Produto = produto,
                Valor = venda.Valor,
                Quantidade = venda.Quantidade,
            };

            return vendaProdutoDTO;
        }

        public string CriarVenda(CriarVendaDTO venda, int usuarioInclusao)
        {
            var novaVenda = _repository.CadastrarVenda(venda, usuarioInclusao);

            return novaVenda;
        }

        public IEnumerable<VendaPostDTO> ConsultarVendaPorComprador(string? nome, string? cpf, int page, int size) {
            return _repository.ConsultarVendaPorComprador(nome, cpf, page, size);
        }
    }
}