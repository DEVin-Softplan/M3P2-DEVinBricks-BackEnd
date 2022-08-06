using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public class EstadosRepository : IEstadosRepository
    {
        private readonly DEVinBricksContext _context;
        public EstadosRepository(DEVinBricksContext context)
        {
            _context = context;
        }

        public IEnumerable<Estado> ConsultarEstados()
        {
            var collection = _context.Estados;
            var resultado = collection.OrderBy(c => c.Nome)
                                      .ToList();

            return resultado;
        }
    }
}
