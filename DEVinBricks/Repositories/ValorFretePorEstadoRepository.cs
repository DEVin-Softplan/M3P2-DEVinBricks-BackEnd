using DEVinBricks.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace DEVinBricks.Repositories
{
    public class ValorFretePorEstadoRepository : IValorFretePorEstadoRepository
    {
        private readonly DEVinBricksContext _context;
        public ValorFretePorEstadoRepository(DEVinBricksContext context)
        {
            _context = context;
          
        }

        public IEnumerable<ValorFretePorEstadoModel> ConsultarValorFreteEstado(string? nome, int page, int size)
        {
            var collection = _context.ValorFreteEstados.Include(x => x.Estado) as IQueryable<ValorFretePorEstadoModel>;

            if (!string.IsNullOrWhiteSpace(nome))
            {
                nome = nome.Trim();
                collection = collection.Where(c => c.Estado.Nome.Contains(nome) || c.Estado.UF.Contains(nome));
            }

            var total = collection.Count();

            var resultado = collection.OrderBy(c => c.Estado.Nome)
                                        .Skip(size * (page - 1))
                                        .Take(size)
                                        .ToList();

            return resultado;
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

        public ValorFretePorEstadoModel ObterPeloEstadoId(int estadoId)
        {
            return _context.ValorFreteEstados.FirstOrDefault(x => x.EstadoId == estadoId);
        }

        public ValorFretePorEstadoModel Adicionar(ValorFretePorEstadoModel model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return model;
        }
    }
}
