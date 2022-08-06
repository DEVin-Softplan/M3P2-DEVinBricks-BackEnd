namespace DEVinBricks.DTO
{
    public class ObterProdutoPorIdDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string UrlDaImagem { get; set; }
        public bool Ativo { get; set; }
        public decimal Valor { get; set; }
    }
}