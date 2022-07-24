using DEVinBricks.DTO;
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
        public ObterProdutoPorIdDTO ObterProdutoPorId(int id)
        {
            var model = _service.ObterProdutoPorId(id);
            var produtoDTO = new ObterProdutoPorIdDTO()
            {
                Id = id,
                Nome = model.Nome,
                Descricao = model.Descricao,
                UrlDaImagem = model.UrlDaImagem,
                Ativo = model.Ativo,
            };

            return produtoDTO;
        }
    }
}
