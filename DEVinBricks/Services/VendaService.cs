using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Services.Interfaces;

namespace DEVinBricks.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _repository;
        public VendaService(IVendaRepository repository)
        {
            _repository = repository;
        }
        public ObterVendaProdutoPorIdVendaDTO ObterVendaProdutoPorIdVenda(int idVenda)
        {
            var model = _repository.ObterVendaPorIdVenda(idVenda);
            var vendaProdutoDTO = new ObterVendaProdutoPorIdVendaDTO()
            {
                Id = model.Id,
                IdVenda = model.IdVenda,
                IdProduto = model.IdProduto,
                Valor = model.Valor,
                Quantidade = model.Quantidade,
            };

            return vendaProdutoDTO;
        }

        public IEnumerable<VendaPostDTO> ConsultarVendaPorComprador(string? nome, string? cpf, int page, int size)
        {
            return _repository.ConsultarVendaPorComprador(nome, cpf, page, size);
        }
    }
}
