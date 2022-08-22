using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVinBricks.DTO
{
    public class CompradorCriarVendaDTO
    {
        public int CompradorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
    }
}
