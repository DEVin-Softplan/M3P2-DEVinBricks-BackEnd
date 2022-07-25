namespace DEVinBricks.Repositories.Models
{
    public partial class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string UrlDaImagem { get; set; }
        public Boolean Ativo { get; set; }

        public Produto()
        {

        }
    }
}