using System;
using System.Collections.Generic;

namespace DEVinBricks.Repositories.Models
{
    public partial class Venda : BaseEntity
    {
     
        public int CompradorId { get; set; }
        public int VendedorId { get; set; }
        public FreteModel FreteId { get; set; }

    }
}