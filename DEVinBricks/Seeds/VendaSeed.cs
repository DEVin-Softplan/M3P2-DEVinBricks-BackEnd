using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Seeds
{
    public class VendaSeed
    {
        public static List<VendaModel> Seed { get; set; } = new List<VendaModel>()
        {
            new VendaModel() {
                Id = 1,
                CompradorId = 1,
                VendedorId = 1,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            },
            new VendaModel() {
                Id = 2,
                CompradorId = 1,
                VendedorId = 1,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            }            
        };
    }
}
