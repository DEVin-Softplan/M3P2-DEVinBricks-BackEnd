namespace DEVinBricks.Repositories.Models
{
    public partial class Venda : BaseEntity
    {        
        public int CompradorId { get; set; }
        public int VendedorId { get; set; }
    }
}