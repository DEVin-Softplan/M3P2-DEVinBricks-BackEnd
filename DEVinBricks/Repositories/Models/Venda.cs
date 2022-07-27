﻿using System;
using System.Collections.Generic;

namespace DEVinBricks.Repositories.Models
{
    public partial class Venda : BaseEntity
    {
     
        public Comprador CompradorId { get; set; }
        public Usuario VendedorId { get; set; }
        public FreteModel FreteId { get; set; }

    }
}