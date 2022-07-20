using System;
using System.Collections.Generic;

namespace DEVinBricks.Models
{
    public partial class Comprador : Log
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
    }
}
