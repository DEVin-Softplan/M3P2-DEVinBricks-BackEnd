using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Seeds
{
    public class ValorFretePorEstadoSeed
    {
        public static List<ValorFretePorEstadoModel> Seed { get; set; } = new List<ValorFretePorEstadoModel>()
        {
           new ValorFretePorEstadoModel()
           {
               Id = 1,
               Valor = 100,
               UsuarioInclusaoId = 1,
               DataDeInclusao = DateTime.Now,
               EstadoId = 42,
            }

        };
    }
}
