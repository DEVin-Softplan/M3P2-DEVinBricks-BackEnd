﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DEVinBricks.Repositories.Models
{
    public partial class Frete : BaseEntity
    {
        public string Cep { get; set; }
        public int EstadoId { get; set; }
        public string Cidade { get; set; }
        public string Logadouro { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
    }
}