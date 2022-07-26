using System;
using System.Collections.Generic;

namespace DEVinBricks.Repositories.Models
{
    public partial class VendasProduto : BaseEntity
    {
        public int Id { get; set; }
        public Venda IdVenda { get; set; }
        public Produto IdProduto { get; set; }
        public int Valor { get; set; }
        public int Quantidade { get; set; }
    }
}