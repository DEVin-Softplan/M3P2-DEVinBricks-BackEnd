using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Services.Interfaces;

namespace DEVinBricks.Services
{
    public class ObterVendaProdutoService : IObterVendaProdutoService
    {
        private readonly IObterVendaProdutoRepository _service;
        public ObterVendaProdutoService(IObterVendaProdutoRepository service)
        {
            _service = service;
        }
        public ObterVendaProdutoPorIdVendaDTO ObterVendaProdutoPorIdVenda(int idVenda)
        {
            var model = _service.ObterVendaProdutoPorIdVenda(idVenda);
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
