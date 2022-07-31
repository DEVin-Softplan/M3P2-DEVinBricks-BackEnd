using DEVinBricks.Repositories.Models;
using DEVinBricks.Services;
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
              Telefone = "1234567891",
              DataDeNascimento = Util.formataStringParaDatetime("01/01/2000"),
              CPF = "34602022030",
              Ativo = true,
              UsuarioInclusaoId = 1
          },
          new Comprador
          {
              Id = 2,
              Nome = "Comprador 2",
              Email = "comprador2@comprador.com.br",
              Telefone = "1234567892",
              DataDeNascimento = Util.formataStringParaDatetime("02/01/2000"),
              CPF = "13574152060",
              Ativo = true,
              UsuarioInclusaoId = 1
          },
          new Comprador
          {
              Id = 3,
              Nome = "Comprador 3",
              Email = "comprador3@comprador.com.br",
              Telefone = "1234567893",
              DataDeNascimento = Util.formataStringParaDatetime("03/01/2000"),
              CPF = "57394817083",
              Ativo = true,
              UsuarioInclusaoId = 1
          },
          new Comprador
          {
              Id = 4,
              Nome = "Comprador 4",
              Email = "comprador4@comprador.com.br",
              Telefone = "1234567894",
              DataDeNascimento = Util.formataStringParaDatetime("04/01/2000"),
              CPF = "39921234056",
              Ativo = true,
              UsuarioInclusaoId = 1
          },
          new Comprador
          {
              Id = 5,
              Nome = "Comprador 5",
              Email = "comprador5@comprador.com.br",
              Telefone = "1234567895",
              DataDeNascimento = Util.formataStringParaDatetime("05/01/2000"),
              CPF = "80202128091",
              Ativo = true,
              UsuarioInclusaoId = 1
          }
        };
    }
}
