﻿using DEVinBricks.Repositories.Models;
using System.ComponentModel.DataAnnotations;

namespace DEVinBricks.DTO
{
    public class CadastroDeProdutoDTO
    {
        public int UsuarioInclusaoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Range(0, int.MaxValue,
        ErrorMessage = "Valor deve ser positivo")]
        public decimal Valor { get; set; }
        public string UrlDaImagem { get; set; }
        public bool Ativo { get; set; }

        public static Produto ConverterParaEntidadeCadastro(CadastroDeProdutoDTO requerido, int id = 0)
        {
            if (requerido == null)
                return null;

            return new Produto()
            {
                Id = id,
                UsuarioInclusaoId = requerido.UsuarioInclusaoId,
                DataDeInclusao = DateTime.UtcNow,
                Nome = requerido.Nome,
                Descricao = requerido.Descricao,
                Valor = requerido.Valor,
                UrlDaImagem = requerido.UrlDaImagem,
                Ativo = requerido.Ativo,

            };
        }
    }
        public class CadastroGetDoDTO
        {
            public string? Nome { get; set; }
            public int PaginaDoCadastro { get; set; }
            public int TamanhoPaginaCadastro { get; set; }

            public static CadastroGetDoDTO ConverterParaEntidadeCadastroGetDoDTO(string? nome, int pagina, int tamanhopagina)
            {
                return new CadastroGetDoDTO()
                {
                    Nome = nome,
                    PaginaDoCadastro = pagina,
                    TamanhoPaginaCadastro = tamanhopagina
                };
            }
        }

    
}
