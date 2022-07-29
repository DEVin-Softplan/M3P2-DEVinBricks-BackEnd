using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Seeds
{
    public class CompradorSeed
    {
        public static List<Comprador> Seed { get; set; } = new List<Comprador>()
        {
            new Comprador() {
                Id = 1,
                Nome = "Comprador Fulano",
                Email = "comprador-fulano@gmail.com",
                Telefone = "1199999999",
                DataDeNascimento = DateTime.Now,
                CPF = "11111111111",
                Ativo = true,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            }
        };

    }
}
