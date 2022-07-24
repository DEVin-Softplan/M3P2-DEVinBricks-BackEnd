using DEVinBricks.Repositories.Models;

namespace DEVinBricks.DTO
{
    public class CompradorPostDTO
    {
        public int UsuarioInclusaoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }

        public static Comprador ConverterParaEntidade(CompradorPostDTO requisicao, int id = 0)
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
    public class CompradorGetDTO
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public int? Pagina { get; set; }
        public int? TamanhoPagina { get; set; }

        public static CompradorGetDTO ConverterParaEntidadeCompradorGetDTO(string? nome, string? cpf, int? pagina, int? tamanhopagina)
        {
            return new CompradorGetDTO()
            {
                Nome = nome,
                CPF = cpf,
                Pagina = pagina,
                TamanhoPagina = tamanhopagina
            };
        }
    }
}
