using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface IValorFretePorEstadoRepository
    {
        public ValorFretePorEstadoModel EditarValorFreteEstado(ValorFretePorEstadoModel frete);
        public ValorFretePorEstadoModel ObterPeloId(int id);
        public IEnumerable<ValorFretePorEstadoModel> ConsultarValorFreteEstado(string? nome, int page, int size);

        public ValorFretePorEstadoModel ObterPeloEstadoId(int estadoId);

        ValorFretePorEstadoModel Adicionar(ValorFretePorEstadoModel model);
    }
}
