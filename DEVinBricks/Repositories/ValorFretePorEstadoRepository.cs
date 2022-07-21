

using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Repositories
{
    public class ValorFretePorEstadoRepository : IValorFretePorEstadoRepository
    {
        private readonly DEVinBricksContext _context;
        public ValorFretePorEstadoRepository(DEVinBricksContext context)
        {
            _context = context;
        }

        public ValorFretePorEstadoModel EditarValorFreteEstado(ValorFretePorEstadoModel frete)
        {
            
           
            _context.ValorFreteEstados.Update(frete);
            _context.SaveChanges();
         

            return frete;
        }

      

        public ValorFretePorEstadoModel ObterPeloId(int id)
        {
            return _context.ValorFreteEstados.FirstOrDefault(x => x.Id == id);
        }

      
    }
}
