using DEVinBricks.Repositories.Models;

namespace DEVinBricks.DTO
{
    public class CadastroDeProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string UrlDaImagem { get; set; }
        public Boolean Ativo { get; set; }

    }
}
