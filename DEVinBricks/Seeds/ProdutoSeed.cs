using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Seeds
{
    public class ProdutoSeed
    {
        public static List<Produto> Seed { get; set; } = new List<Produto>()
        {
            new Produto() {
                Id = 1,
                Nome = "Monitor Dell",
                Descricao = "21 polegadas",
                Valor = 300.00M,
                UrlDaImagem = "",
                Ativo = true,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            },
            new Produto() {
                Id = 2,
                Nome = "Teclado Logitech",
                Descricao = "Mas é o mais simples da marca",
                Valor = 100.00M,
                UrlDaImagem = "",
                Ativo = true,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            },
            new Produto() {
                Id = 3,
                Nome = "Mouse Logitech",
                Descricao = "Também é o mais simples possível",
                Valor = 50.00M,
                UrlDaImagem = "",
                Ativo = true,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            }
        };
    }
}
