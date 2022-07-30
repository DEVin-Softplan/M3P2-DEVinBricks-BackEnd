using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Services.Interfaces;

namespace DEVinBricks.Services
{
    public class EstadosService : IEstadosService
    {
        private readonly IEstadosRepository _repository;
        public EstadosService(IEstadosRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Estado> ConsultarEstados()
        {
            return _repository.ConsultarEstados();
        }
    }
}
