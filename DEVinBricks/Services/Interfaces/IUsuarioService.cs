﻿using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<int> CadastrarUsuario(Usuario usuario);
        Task<bool> VerificaSeEmailExiste(string email);
    }
}