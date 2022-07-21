using System.ComponentModel.DataAnnotations;

namespace DEVinBricks.DTO
{
    public class ValorFretePorEstadoDTO
    {
        public int Id { get; set; }
        [Range(0, int.MaxValue,
      ErrorMessage = "Valor deve ser positivo")]
        public decimal Valor { get; set; }
    }
}
