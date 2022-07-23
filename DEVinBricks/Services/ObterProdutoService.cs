using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Services.Interfaces;

namespace DEVinBricks.Services
{
    public class ObterProdutoService : IObterProdutoService
    {
        private readonly IObterProdutoRepository _service;
        public ObterProdutoService(IObterProdutoRepository service)
        {
            _service = service;
        }
        public Produto ObterProdutoPorId(int id)
        {
            var model = _service.ObterProdutoPorId(id);

            return model;
        }
    }
}
