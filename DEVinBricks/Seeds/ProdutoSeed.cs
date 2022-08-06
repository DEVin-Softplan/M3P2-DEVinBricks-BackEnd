using DEVinBricks.Repositories.Models;

namespace DEVinBricks.Seeds
{
    public class ProdutoSeed
    {
        public static List<Produto> Seed { get; set; } = new List<Produto>()
        {
            new Produto
            {
                Id = 1,
                Nome = "Cimento",
                Descricao = "Cimento top",
                Valor = 200M,
                UrlDaImagem = "https://balaroti.vtexassets.com/arquivos/ids/2578293/7278.jpg?v=637508061483670000",
                Ativo = true,
                UsuarioInclusaoId = 1
            },
            new Produto
            {
                Id = 2,
                Nome = "Areia",
                Descricao = "Areia top",
                Valor = 100M,
                UrlDaImagem = "https://cdn.leroymerlin.com.br/products/areia_fina_lavada_saco_20kg_grupo_tomino_89851650_636e_300x300.jpg",
                Ativo = true,
                UsuarioInclusaoId = 1
            },
            new Produto
            {
                Id = 3,
                Nome = "Bitoneira",
                Descricao = "Bitoneira top",
                Valor = 100000M,
                UrlDaImagem = "https://a-static.mlcdn.com.br/1500x1500/betoneira-400-litros-com-motor-1-traco-super-csm/palaciodasferramentas/53812/7c7b9bfadd0b3063f3adf248843ed9fa.jpg",
                Ativo = true,
                UsuarioInclusaoId = 1
            },
        };
    };
}
