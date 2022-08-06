using DEVinBricks.Repositories.Models;

namespace DEVinBricks.DTO
{    
    public class VendaProdutoGetDTO
    {
        public int Id { get; set; }
        public int IdVenda { get; set; }
        public VendaModel Venda { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }

        public static VendaProdutoGetDTO ConverterParaVendaProdutoGetDTO(VendaProdutoModel entidade)
        {
            return new VendaProdutoGetDTO()
            {
                Id = entidade.Id,
                IdVenda = entidade.IdVenda,
                //Venda = entidade.Venda,
                IdProduto = entidade.IdProduto,
                //Produto = entidade.Produto,
                Valor = entidade.Valor,
                Quantidade = entidade.Quantidade,
            };
        }

        public static VendaProdutoModel ConverterParaEntidadeVendaProduto(VendaProdutoGetDTO requisicao)
        {
            if (requisicao == null)
                return null;

            return new VendaProdutoModel()
            {
                Id = requisicao.Id,
                IdVenda = requisicao.IdVenda,
                Venda = requisicao.Venda,
                IdProduto = requisicao.IdProduto,
                Produto = requisicao.Produto,
                Valor = requisicao.Valor,
                Quantidade = requisicao.Quantidade,
            };
        }
    }
}
