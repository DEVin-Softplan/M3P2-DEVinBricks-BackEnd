﻿using System;
using System.Collections.Generic;

namespace DEVinBricks.Repositories.Models
{
    public partial class VendaProduto : BaseEntity
    {
        public int Id { get; set; }
        public int IdVenda { get; set; }
        //public Venda Venda { get; set; }
        public int IdProduto { get; set; }
        //public Produto Produto { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
    }
}