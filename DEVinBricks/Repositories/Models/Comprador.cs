namespace DEVinBricks.Repositories.Models
{
    public partial class Comprador : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
    }
}
