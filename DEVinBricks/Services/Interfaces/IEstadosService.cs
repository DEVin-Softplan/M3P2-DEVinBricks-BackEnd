using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Services.Interfaces
{
    public interface IEstadosService
    {
        IEnumerable<Estado> ConsultarEstados();
    }
}
