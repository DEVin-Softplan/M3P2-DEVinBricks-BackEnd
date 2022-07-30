using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface IEstadosRepository
    {
        public IEnumerable<Estado> ConsultarEstados();
    }
}
