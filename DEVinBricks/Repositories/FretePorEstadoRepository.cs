using DEVinBricks.Models;

namespace DEVinBricks.Repositories
{
    public class FretePorEstadoRepository : IFretePorEstadoRepository
    {
        private readonly DEVinBricksContext _context;
        public FretePorEstadoRepository(DEVinBricksContext context)
        {
            _context = context;
        }
        public int EditaEstado(int id)
        {

            return StatusCodes.Status200OK;
           
        }
    }
}
