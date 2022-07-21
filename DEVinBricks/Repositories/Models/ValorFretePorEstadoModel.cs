using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DEVinBricks.Repositories.Models
{
    public partial class ValorFretePorEstadoModel : BaseEntity
    {
      
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }

        [Range(0, int.MaxValue,
       ErrorMessage = "Valor deve ser positivo")]
        public decimal Valor { get; set; }

    }
}
