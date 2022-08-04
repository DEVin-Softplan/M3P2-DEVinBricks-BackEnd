namespace DEVinBricks.Repositories.Models
{
    public partial class VendaModel : BaseEntity
    {        
        public int CompradorId { get; set; }
        public Comprador Comprador { get; set; }
        public int VendedorId { get; set; }
        public Usuario Vendedor { get; set; }
        //public int FreteId { get; set; }
        //public FreteModel Frete { get; set; }
    }
}