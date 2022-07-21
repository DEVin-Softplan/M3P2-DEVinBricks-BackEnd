using DEVinBricks.DTO;
using DEVinBricks.Repositories;
using DEVinBricks.Repositories.Models;
using DEVinBricks.Services.Interfaces;

namespace DEVinBricks.Services
{
    public class ValorFretePorEstadoService : IValorFretePorEstadoService
    {

        private readonly IValorFretePorEstadoRepository _repository;
        public ValorFretePorEstadoService(IValorFretePorEstadoRepository repository)
        {
            _repository = repository;
        }

        public ValorFretePorEstadoModel Atualizar(ValorFretePorEstadoDTO dto)
        {
            var model = _repository.ObterPeloId(dto.Id);
            model.Valor = dto.Valor;
            return _repository.EditarValorFreteEstado(model);
        }

        public bool VerificarSeExiste(int id) => _repository.ObterPeloId(id) == null;



    }
}
