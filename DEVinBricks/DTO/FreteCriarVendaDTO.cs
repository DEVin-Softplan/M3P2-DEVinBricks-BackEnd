using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVinBricks.DTO
{
    public class FreteCriarVendaDTO
    {
        public string Cep { get; set; }
        public int EstadoId { get; set; }
        public string Cidade { get; set; }
        public string Logadouro { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public DateTime DataDeEntrega { get; set; }
        public decimal ValorFrete { get; set; }
    }
}
