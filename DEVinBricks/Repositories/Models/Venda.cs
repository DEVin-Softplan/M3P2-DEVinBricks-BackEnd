﻿using System;
using System.Collections.Generic;

namespace DEVinBricks.Repositories.Models
{
    public partial class Venda : BaseEntity
    {
        public int Id { get; set; }
        public Comprador CompradorId { get; set; }
        public Usuario VendedorId { get; set; }
        public Frete FreteId { get; set; }
        public DateTime DataDeInclusao { get; set; }
        public Usuario IdUsuarioInclusao { get; set; }
        public DateTime DataDeAlteracao { get; set; }
        public Usuario IdUsuarioAlteracao { get; set; }
    }
}