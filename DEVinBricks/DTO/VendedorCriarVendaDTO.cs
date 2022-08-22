using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVinBricks.DTO
{
    public class VendedorCriarVendaDTO
    {
        public int VendedorId { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public bool Admin { get; set; }
        public bool Ativo { get; set; }
    }
}
