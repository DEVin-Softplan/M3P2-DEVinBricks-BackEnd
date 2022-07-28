﻿using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;
using static DEVinBricks.DTO.CadastroDeProdutoDTO;

namespace DEVinBricks.Repositories
{
    public interface ICadastroDeProdutoRepository
    {
        public Task<int> CadastrarProduto(CadastroDeProdutoDTO produtoDTO);
        IEnumerable<Produto> ListarProdutos(CadastroGetDoDTO produtoDTO);
        bool VerificaSeExisteProduto(string nome);
        public Produto ObterPeloIdCadastro(int id);
    }
}
