using System.ComponentModel.DataAnnotations;

namespace DEVinBricks.DTO
{
    public class ValorFretePorEstadoPostDTO
    {
        public int Id { get; set; }
        public int EstadoId { get; set; }

        [Range(0, int.MaxValue,
        ErrorMessage = "Valor deve ser positivo")]
        public decimal Valor { get; set; }
    }
}