using DEVinBricks.Repositories.Models;

namespace DEVinBricks.DTO
{
    public class FreteDTO
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public int EstadoId { get; set; }
        public string Cidade { get; set; }
        public string Logadouro { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public DateTime DataDeEntrega { get; set; }
        public decimal ValorFrete { get; set; }
        public DateTime DataDeInclusao { get; set; }
        public int UsuarioInclusaoId { get; set; }
        public DateTime? DataDeAlteracao { get; set; }
        public int? UsuarioAlteracaoId { get; set; }

        public static Frete ConverterParaEntidade(FreteDTO requisicao, int id = 0)
        {
            if (requisicao == null)
                return null;

            return new Frete()
            {
                Id = id,
                Cep = requisicao.Cep,
                EstadoId = requisicao.EstadoId,
                Cidade = requisicao.Cidade,
                Logadouro = requisicao.Logadouro,
                Bairro = requisicao.Bairro,
                Complemento = requisicao.Complemento,
                DataDeEntrega = DateTime.UtcNow,
                ValorFrete = requisicao.ValorFrete,
                DataDeInclusao = DateTime.UtcNow,
                UsuarioInclusaoId = requisicao.UsuarioInclusaoId,
                DataDeAlteracao = DateTime.UtcNow,
                UsuarioAlteracaoId = requisicao.UsuarioAlteracaoId,
            };
        }
    }
}
