namespace DEVinBricks.Repositories.Models
{
    public partial class Produto : BaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string UrlDaImagem { get; set; }
        public Boolean Ativo { get; set; }
        public DateTime IdUsuarioInclusao { get; set; }
        public DateTime DataDeAlteracao { get; set; }
        public int IdUsuarioAlteracao { get; set; }

        public Produto()
        {

        }
    }
}
