using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Seeds
{
    public class VendaSeed
    {
        public static List<Venda> Seed { get; set; } = new List<Venda>()
        {
            new Venda() {
                Id = 1,
                CompradorId = 1,
                VendedorId = 1,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            },
            new Venda() {
                Id = 2,
                CompradorId = 1,
                VendedorId = 1,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            }            
        };
    }
}
