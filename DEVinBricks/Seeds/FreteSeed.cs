using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Seeds
{
    public class FreteSeed
    {
        public static List<FreteModel> Seed { get; set; } = new List<FreteModel>()
        {
            new FreteModel 
            {
                Id = 1,
                Cep = "0123456-789",
                EstadoId = 11,
                Cidade = "Porto Velho",
                Logadouro = "Rua Vasco da Gama, 123",
                Bairro = "Vasco",
                Complemento = "Casa 98",
                DataDeEntrega = DateTime.Now,
                ValorFrete = 27M,
                DataDeInclusao = DateTime.Now,
                UsuarioInclusaoId = 1,
                DataDeAlteracao = DateTime.Now,
                UsuarioAlteracaoId = 1
            },
            new FreteModel
            {
                Id = 2,
                Cep = "345631-127",
                EstadoId = 12,
                Cidade = "Parque Jurassico",
                Logadouro = "Rua Dino, 456",
                Bairro = "T-REX",
                Complemento = "Casa 47",
                DataDeEntrega = DateTime.Now,
                ValorFrete = 53M,
                DataDeInclusao = DateTime.Now,
                UsuarioInclusaoId = 1,
                DataDeAlteracao = DateTime.Now,
                UsuarioAlteracaoId = 1
            },
            new FreteModel
            {
                Id = 3,
                Cep = "999999-888",
                EstadoId = 13,
                Cidade = "Manaus",
                Logadouro = "Rua do Acai, 789",
                Bairro = "Acai",
                Complemento = "Casa 12",
                DataDeEntrega = DateTime.Now,
                ValorFrete = 32M,
                DataDeInclusao = DateTime.Now,
                UsuarioInclusaoId = 1,
                DataDeAlteracao = DateTime.Now,
                UsuarioAlteracaoId = 1
            },
        };
    }
}
