

using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public interface IValorFretePorEstadoRepository
    {

        public ValorFretePorEstadoModel EditarValorFreteEstado(ValorFretePorEstadoModel frete);

     
        public ValorFretePorEstadoModel ObterPeloId(int id);
    }
}
