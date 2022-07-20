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
        public Estado EditaEstado(int id)
        {

           
           
        }
    }
}
