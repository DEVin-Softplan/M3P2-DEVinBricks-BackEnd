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

        public async Task<Usuario> CadastrarUsuario(Usuario usuario)
        {
            try
            {
                var resultado = await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
                return usuario;
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
                usuarios = _context.Usuarios.Include(x => x.UsuarioInclusao).Include(x => x.UsuarioAlteracao).ToList();
            }
            if (nome != "sem nome" && login == "sem login")
            {
                usuarios = _context.Usuarios.Where(x => x.Nome == nome).Include(x => x.UsuarioInclusao).Include(x => x.UsuarioAlteracao).ToList();
            }
            if (nome == "sem nome" && login != "sem login")
            {
                usuarios = _context.Usuarios.Where(x => x.Login == login).Include(x => x.UsuarioInclusao).Include(x => x.UsuarioAlteracao).ToList();
            }
            if (nome != "sem nome" && login != "sem login")
            {
                usuarios = _context.Usuarios.Where(x => x.Nome == nome && x.Login == login).Include(x => x.UsuarioInclusao).Include(x => x.UsuarioAlteracao).ToList();
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
            return _context.Usuarios.Include(x => x.UsuarioInclusao).Include(x => x.UsuarioAlteracao).FirstOrDefault(x => x.Id == id);
        }

        public async Task<Usuario> AlterarDados(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Update(usuario);

                await _context.SaveChangesAsync();

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception($"mensagem,: {ex.Message}", ex.InnerException);
            }
        }

    }
}
