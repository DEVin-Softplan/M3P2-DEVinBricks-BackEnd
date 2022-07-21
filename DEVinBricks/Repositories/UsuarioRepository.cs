using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVinBricks.Services
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private DEVinBricksContext _context;
        public UsuarioRepository(DEVinBricksContext context)
        {
            _context = context;
        }

        public async Task<int> CadastrarUsuario(Usuario usuario)
        {
            try
            {
                var resultado = await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
                return resultado.Entity.Id;
            }
            catch (Exception ex)
            {

                throw new Exception($"mensagem: { ex.Message }", ex.InnerException);
            }
        }

        public List<Usuario> listarUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario ObterPorLoginESenha(string login, string senha)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToLower() == login && x.Senha == senha);
        }

        public async Task<bool> VerificaSeEmailExiste(string email)
        {
            try
            {
                var resultado = await _context.Usuarios.Where(x => x.Email == email)
                    .AsNoTracking()
                    .AnyAsync();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }
    }
}
