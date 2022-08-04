using System;
using System.Collections.Generic;

namespace DEVinBricks.Repositories.Models
{
    public partial class Venda : BaseEntity
    {
     
        public Comprador Comprador { get; set; }
        public Usuario Vendedor { get; set; }
        public FreteModel Frete { get; set; }

        public int CompradorId { get; set; }
        public int VendedorId { get; set; }
        public int FreteId { get; set; }

    }
}
