using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVinBricks.Repositories
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

        public List<Usuario> listarUsuarios(string nome, string login, int tamanho, int pagina)
        {
            var usuarios = new List<Usuario>();
            if (nome == "sem nome" && login == "sem login")
            {
                usuarios = _context.Usuarios.ToList();
            }
            if (nome != "sem nome" && login == "sem login")
            {
                usuarios = _context.Usuarios.Where(x => x.Nome == nome).ToList();
            }
            if (nome == "sem nome" && login != "sem login")
            {
                usuarios = _context.Usuarios.Where(x => x.Login == login).ToList();
            }
            if (nome != "sem nome" && login != "sem login")
            {
                usuarios = _context.Usuarios.Where(x => x.Nome == nome && x.Login == login).ToList();
            }

            if (tamanho != 0)
            {
                var skip = ((pagina - 1) * tamanho);
                usuarios = usuarios.Skip(skip).Take(tamanho).ToList();
            }
            return usuarios;
        }

        public Usuario ObterPorLoginESenha(string login, string senha)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToLower() == login && x.Senha == senha);
        }

        public async Task<bool> VerificarSeEmailExiste(string email)
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

        public async Task<bool> VerificarSeLoginExiste(string login)
        {
            try
            {
                var resultado = await _context.Usuarios.Where(x => x.Login == login)
                    .AsNoTracking()
                    .AnyAsync();
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }

        public Usuario ObterUsuarioPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public async Task AlterarDados(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Update(usuario);

                await _context.SaveChangesAsync();

                return;
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }

    }
}
