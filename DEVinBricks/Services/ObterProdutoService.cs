using DEVinBricks.DTO;
using DEVinBricks.Repositories;
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

        public List<ObterListaProdutoDTO> ObterListaProduto(string? nome, int pagina, int tamanhoPagina)
        {
            var produtos = _service.ObterListaProduto(nome, pagina, tamanhoPagina);

            var model = new List<ObterListaProdutoDTO>();
            foreach (var item in produtos)
            {
                model.Add(new ObterListaProdutoDTO()
                {
                    Id = item.Id,
                    Nome = item.Nome,
                    Descricao = item.Descricao,
                    Valor = item.Valor,
                    Ativo = item.Ativo,
                });
            }

            return model;
        }
    }
}

