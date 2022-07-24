using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Seeds
{
    public class UsuarioSeed
    {
        public static Usuario usuario { get; set; } = new Usuario()
        {
            Id = 1,
            Nome = "Admin",
            Senha = "admin123",
            Email = "admin@gmail.com",
            Login = "admin",
            Admin = true,
            Ativo = true,
            UsuarioInclusaoId = 1,
            DataDeInclusao = DateTime.Now,

        };
    }
}
