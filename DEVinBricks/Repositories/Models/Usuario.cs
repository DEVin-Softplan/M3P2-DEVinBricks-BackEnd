using System;
using System.Collections.Generic;

namespace DEVinBricks.Repositories.Models
{
    public partial class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public bool Admin { get; set; }
        public bool Ativo { get; set; }

        public Usuario()
        {
        }
    }
}
