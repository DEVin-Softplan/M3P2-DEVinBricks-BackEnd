using System;
using System.Collections.Generic;

namespace DEVinBricks.Repositories.Models {
    public partial class VendaProdutoModel : BaseEntity {
        public int Id { get; set; }
        public int IdVenda { get; set; }
        public VendaModel Venda { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
    }
}