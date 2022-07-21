

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEVinBricks.Repositories.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataDeInclusao { get; set; }
        [ForeignKey("UsuarioInclusao")]
        public int UsuarioInclusaoId { get; set; }
      
        public Usuario UsuarioInclusao { get; set; }
        public DateTime? DataDeAlteracao { get; set; }
        [ForeignKey("UsuarioAlteracao")]
        public int? UsuarioAlteracaoId { get; set; }
        public Usuario? UsuarioAlteracao { get; set; }
    }
}
