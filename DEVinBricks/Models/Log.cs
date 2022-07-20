namespace DEVinBricks.Models
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime DataDeInclusao { get; set; }
        public int IdUsuarioInclusao { get; set; }
        public DateTime? DataDeAlteracao { get; set; }
        public int? IdUsuarioAlteracao { get; set; }
    }
}
