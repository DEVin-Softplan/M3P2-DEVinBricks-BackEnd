using DEVinBricks.Repositories.Models;

namespace DEVinBricks.DTO
{
    public class CompradorDTO
    {
        public int UsuarioInclusaoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }

        public static Comprador ConverterParaEntidade(CompradorDTO requisicao, int id = 0)
        {
            if (requisicao == null)
                return null;

            return new Comprador()
            {
                Id = id,
                UsuarioInclusaoId = requisicao.UsuarioInclusaoId,
                DataDeInclusao = DateTime.UtcNow,
                Nome = requisicao.Nome,
                Email = requisicao.Email,
                Telefone = requisicao.Telefone,
                DataDeNascimento = requisicao.DataDeNascimento,
                CPF = requisicao.CPF,
                Ativo = requisicao.Ativo,
            };
        }
    }
}
