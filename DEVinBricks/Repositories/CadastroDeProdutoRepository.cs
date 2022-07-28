﻿using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;
using static DEVinBricks.DTO.CadastroDeProdutoDTO;

namespace DEVinBricks.Repositories
{
    public class CadastroDeProdutoRepository : ICadastroDeProdutoRepository
    {
        private DEVinBricksContext _context;

        public async Task<int> CadastrarProduto(CadastroDeProdutoDTO produtoDTO)
        {
            var newProdutoModel = CadastroDeProdutoDTO.ConverterParaEntidadeCadastro(produtoDTO);
            var resultadoDeCadastro = await _context.Produtos.AddAsync(newProdutoModel);
            await _context.SaveChangesAsync();
            return resultadoDeCadastro.Entity.Id;
        }

        public IEnumerable<ProdutoModel> ListarProdutos(CadastroGetDoDTO produtoDTO)
        {
            var queryableProdutoModel = _context.Produtos as IQueryable<ProdutoModel>;
            if (!string.IsNullOrWhiteSpace(produtoDTO.Nome))
                queryableProdutoModel = queryableProdutoModel.Where(c => c.Nome.Contains(produtoDTO.Nome));
            if (produtoDTO.PaginaDoCadastro > 0)
                queryableProdutoModel = queryableProdutoModel
                                    .Skip((produtoDTO.PaginaDoCadastro - 1) * produtoDTO.TamanhoPaginaCadastro)
                                    .Take(produtoDTO.TamanhoPaginaCadastro);
            var resultado = queryableProdutoModel.OrderBy(c => c.Nome).ToList();
            return resultado;
        }

        public ProdutoModel ObterProduto(int id)
        {
            throw new NotImplementedException();
        }

        public bool VerificaSeExisteProduto(string nome)
        {
            return _context.Produtos.Any(x => x.Nome == nome);
        }
        public ProdutoModel ObterPeloIdCadastro(int id)
        {
            return _context.Produtos.FirstOrDefault(x => x.Id == id);
        }
    }
}
