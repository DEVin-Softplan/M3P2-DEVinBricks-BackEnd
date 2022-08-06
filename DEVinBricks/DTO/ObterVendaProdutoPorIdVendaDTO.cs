using DEVinBricks.Repositories.Models;

namespace DEVinBricks.DTO
{
    public class ObterVendaProdutoPorIdVendaDTO
    {
        public int Id { get; set; }
        public VendaModel Venda { get; set; }
        public int IdVenda { get; set; }
        public Produto Produto { get; set; }        
        public int IdProduto { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
    }
}