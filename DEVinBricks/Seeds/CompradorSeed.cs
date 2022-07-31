using DEVinBricks.Repositories.Models;
using System.Globalization;

namespace DEVinBricks.Seeds
{
    public class CompradorSeed
    {
        public static List<Comprador> Seed { get; set; } = new List<Comprador>() {
          new Comprador
          {
              Id = 1,
              Nome = "Comprador 1",
              Email = "comprador1@comprador.com.br",
              Telefone = "(12) 3456-7891",
              DataDeNascimento = DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", new CultureInfo("pt-BR")),
              CPF = "12345678911",
              Ativo = true,
              UsuarioInclusaoId = 1
          },
          new Comprador
          {
              Id = 2,
              Nome = "Comprador 2",
              Email = "comprador2@comprador.com.br",
              Telefone = "(12) 3456-7892",
              DataDeNascimento = DateTime.ParseExact("02/01/2000", "dd/MM/yyyy", new CultureInfo("pt-BR")),
              CPF = "12345678912",
              Ativo = true,
              UsuarioInclusaoId = 1
          },
          new Comprador
          {
              Id = 3,
              Nome = "Comprador 3",
              Email = "comprador3@comprador.com.br",
              Telefone = "(12) 3456-7893",
              DataDeNascimento = DateTime.ParseExact("03/01/2000", "dd/MM/yyyy", new CultureInfo("pt-BR")),
              CPF = "12345678913",
              Ativo = true,
              UsuarioInclusaoId = 1
          },
          new Comprador
          {
              Id = 4,
              Nome = "Comprador 4",
              Email = "comprador4@comprador.com.br",
              Telefone = "(12) 3456-7894",
              DataDeNascimento = DateTime.ParseExact("04/01/2000", "dd/MM/yyyy", new CultureInfo("pt-BR")),
              CPF = "12345678914",
              Ativo = true,
              UsuarioInclusaoId = 1
          },
          new Comprador
          {
              Id = 5,
              Nome = "Comprador 5",
              Email = "comprador5@comprador.com.br",
              Telefone = "(12) 3456-7895",
              DataDeNascimento = DateTime.ParseExact("05/01/2000", "dd/MM/yyyy", new CultureInfo("pt-BR")),
              CPF = "12345678915",
              Ativo = true,
              UsuarioInclusaoId = 1
          }
        };
    }
}
