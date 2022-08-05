using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Services.Interfaces;

namespace DEVinBricks.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _service;
        public ProdutoService(IProdutoRepository service)
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
                Valor = model.Valor,
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
                    Url = item.UrlDaImagem,
                });
            }

            return model;
        }

        public Produto EditarProduto(ObterProdutoPorIdDTO produto, int IdUsuarioAlteracao)
        {
            var model = _service.ObterProdutoPorId(produto.Id);
            model.Nome = produto.Nome;
            model.Descricao = produto.Descricao;
            model.Valor = produto.Valor;
            model.UrlDaImagem = produto.UrlDaImagem;
            model.Ativo = produto.Ativo;
            model.DataDeAlteracao = DateTime.Now;
            model.UsuarioAlteracaoId = IdUsuarioAlteracao;

            return _service.EditarProduto(model);
        }

        public bool VerificaNome(string nome)
        {
            return _service.VerificaNome(nome);         
        }


    }
}

