using DEVinBricks.DTO;
using DEVinBricks.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVinBricks.Repositories
{
    public class FreteRepository: IFreteRepository
    {
        private DEVinBricksContext _context;
        public FreteRepository(DEVinBricksContext context)
        {
            _context = context;
        }

        public FreteModel ObterFretePorId(int id)
        {
            return _context.Fretes.Find(id);
        }
    }
}
