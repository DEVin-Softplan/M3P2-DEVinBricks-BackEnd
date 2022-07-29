using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Seeds
{
    public class VendaProdutoSeed
    {
        public static List<VendaProduto> Seed { get; set; } = new List<VendaProduto>()
        {
            new VendaProduto() {
                Id = 1,
                IdVenda = 1,
                IdProduto = 1,
                Quantidade = 1,
                Valor = 300.00,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            },
            new VendaProduto() {
                Id = 2,
                IdVenda = 1,
                IdProduto = 2,
                Quantidade = 1,
                Valor = 100.00,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            },            
            new VendaProduto() {
                Id = 3,
                IdVenda = 1,
                IdProduto = 3,
                Quantidade = 1,
                Valor = 500.00,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            },
            new VendaProduto()
            {
                Id = 4,
                IdVenda = 2,
                IdProduto = 3,
                Quantidade = 2,
                Valor = 50,
                UsuarioInclusaoId = 1,
                DataDeInclusao = DateTime.Now,
            }
        };
    }
}
