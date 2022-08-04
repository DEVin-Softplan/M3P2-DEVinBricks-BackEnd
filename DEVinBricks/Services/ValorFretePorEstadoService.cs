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

        public ValorFretePorEstadoModel Atualizar(ValorFretePorEstadoDTO dto, int idUsuarioAlteracao)
        {
            var model = _repository.ObterPeloId(dto.Id);
            model.Valor = dto.Valor;
            model.UsuarioAlteracaoId = idUsuarioAlteracao;
            model.DataDeAlteracao = DateTime.Now;
            return _repository.EditarValorFreteEstado(model);
        }

        public IEnumerable<ValorFretePorEstadoModel> Consultar(string? nome, int page, int size)
        {
            return _repository.ConsultarValorFreteEstado(nome, page, size);
        }

        public bool VerificarSeExiste(int id) => _repository.ObterPeloId(id) == null;

        public bool VerificarSeExisteCadastroDoEstado(int estadoId)
        {
            var cadastro = _repository.ObterPeloEstadoId(estadoId);
            return cadastro != null;
        }

        public ValorFretePorEstadoModel Adicionar(ValorFretePorEstadoPostDTO dto, int idUsuarioInclusao)
        {
            var model = new ValorFretePorEstadoModel()
            {
                DataDeInclusao = DateTime.Now,
                EstadoId = dto.EstadoId,
                UsuarioInclusaoId = idUsuarioInclusao,
                Valor = dto.Valor
            };
            return _repository.Adicionar(model);
        }
    }
}