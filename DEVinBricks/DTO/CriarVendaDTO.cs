namespace DEVinBricks.DTO
{
    public class CriarVendaDTO
    {
        public ObterProdutoPorIdDTO Produto { get; set; }
        public CompradorCriarVendaDTO Comprador { get; set; }
        public VendedorCriarVendaDTO Vendedor { get; set; }
        public FreteCriarVendaDTO Frete { get; set; }
    }
}