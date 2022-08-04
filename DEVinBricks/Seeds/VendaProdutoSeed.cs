﻿using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Seeds
{
    public class VendaProdutoSeed
    {
        public static List<VendaProdutoModel> Seed { get; set; } = new List<VendaProdutoModel>()
        {
            new VendaProdutoModel() {
                Id = 1,
                IdVenda = 1,
                IdProduto = 1,
                Quantidade = 1,
                Valor = 300.00,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            },
            new VendaProdutoModel() {
                Id = 2,
                IdVenda = 1,
                IdProduto = 2,
                Quantidade = 1,
                Valor = 100.00,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            },            
            new VendaProdutoModel() {
                Id = 3,
                IdVenda = 1,
                IdProduto = 3,
                Quantidade = 1,
                Valor = 500.00,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            },
            new VendaProdutoModel()
            {
                Id = 4,
                IdVenda = 2,
                IdProduto = 3,
                Quantidade = 2,
                Valor = 50,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            }
        };
    }
}