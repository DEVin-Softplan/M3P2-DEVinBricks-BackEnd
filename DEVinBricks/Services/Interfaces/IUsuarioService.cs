﻿using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> CadastrarUsuario(Usuario usuario);
        Task<Usuario> CriarUsuario(CadastrarUsuarioDTO usuario, int idInclusao);
        Task<bool> VerificarSeEmailExiste(string email);
        void EnviarEmailParaFila(Usuario usuario);
        Task<Usuario> VerificarDadosAlterados(EditarUsuarioDTO usuarioAlterado);
        bool verificaSeTemConteudo(string texto);
        Task<Usuario> AlterarDadosUsuario(Usuario usuarioAlterado, int idUsuarioAlteracao);
        Task<bool> VerificarSeLoginExiste(string login);
    }
}
