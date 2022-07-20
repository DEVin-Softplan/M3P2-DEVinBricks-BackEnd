using DEVinBricks.DTO;
using DEVinBricks.Models;
using DEVinBricks.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DEVinBricks.Services
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private DEVinBricksContext _context;
        public UsuarioRepository(DEVinBricksContext context)
        {
            _context = context;
        }

        public List<Usuario> listarUsuarios()
        {
            return _context.Usuarios.ToList();
        }

    }
}
