using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Services.Interfaces;

namespace DEVinBricks.Services
{
    public class ObterVendaProdutoService : IVendaService
    {
        private readonly IVendaRepository _service;
        public ObterVendaProdutoService(IVendaRepository service)
        {
            _service = service;
        }
        public ObterVendaProdutoPorIdVendaDTO ObterVendaProdutoPorIdVenda(int idVenda)
        {
            var model = _service.ObterVendaPorIdVenda(idVenda);
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
    }
}
